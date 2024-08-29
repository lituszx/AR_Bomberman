using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyState   state;
    public float        speed;
    public Direction    direction = Direction.LEFT;

    private float       _stateTime;
    private Rigidbody   _body;
    private GameManager _gm;
    private void Awake()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
        direction = (Direction)Random.Range(0, System.Enum.GetValues(typeof(Direction)).Length);
        if (speed == 0)
            speed = 1;

        ChangeState();
    }



    private void Update()
    {
        TimeToNewState();
        switch (state)
        {
            case EnemyState.IDLE:
                break;
            case EnemyState.MOVE:
                Vector3 pos = transform.position;
                switch (direction)
                {
                    case Direction.UP:
                        pos.x = Mathf.Round(transform.position.x);
                        transform.forward = Vector3.forward;
                        break;
                    case Direction.DOWN:
                        pos.x = Mathf.Round(transform.position.x);
                        transform.forward = Vector3.back;
                        break;
                    case Direction.LEFT:
                        pos.z = Mathf.Round(transform.position.z);
                        transform.forward = Vector3.left;
                        break;
                    case Direction.RIGHT:
                        pos.z = Mathf.Round(transform.position.z);
                        transform.forward = Vector3.right;
                        break;
                }

                transform.position = pos;
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
                break;
            case EnemyState.CHASE:
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
                break;
        }
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
        {
            if (hitInfo.collider.tag == Constants.TAG_PLAYER)
            {
                state = EnemyState.CHASE;
            }
            else
            {
                if (state == EnemyState.CHASE)
                    ChangeState();
            }
        }
    }

    private void ChangeState()
    {

        state       = (EnemyState) Random.Range(0, 2);
        switch (state)
        {
            case EnemyState.IDLE:
                    _stateTime  = Random.Range(0, Constants.MIN_STATE_TIME);
                break;
            case EnemyState.MOVE:
                    _stateTime  = Random.Range(Constants.MIN_STATE_TIME, Constants.MAX_STATE_TIME);
                break;
        }
       
    }

    private void ChangeDirection(Direction oldDirection)
    {
        while (oldDirection == direction)
        {
            direction = (Direction)Random.Range(0, System.Enum.GetValues(typeof(Direction)).Length);
        }
    }

    public void TimeToNewState()
    {
        _stateTime -= Time.deltaTime;
        if (_stateTime <= 0)
            ChangeState();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.TAG_PLAYER)
        {
            //Loose
            _gm.Loose();
        }

        ChangeDirection(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Constants.TAG_EXPLOSION)
        {
            _gm.AddPoints(Constants.KILL_ENEMY_POINTS);
            Destroy(gameObject);
        }
    }
}
