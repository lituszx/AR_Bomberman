using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // var public
    public GameObject   prefabBomb;
    [Range(1,4)]
    public int          rangeExplosion;
    public int          currentBombs;

    //var private
    private float       _speed;
    private GameManager _gm;

    //getters and setters
    public float speed { set { _speed = value; } get { return _speed; } }
    private void Start()
    {
        _speed          = Constants.MIN_SPEED_PLAYER;
        currentBombs    = 1;
        rangeExplosion  = Constants.MIN_RANGE_PLAYER;

        _gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveTo = new Vector3(_gm.horizontal.value, 0, _gm.vertical.value);
        moveTo *= Time.deltaTime * _speed;
        transform.position = transform.position + moveTo;

        if (moveTo == Vector3.zero)
            moveTo = transform.forward;
        transform.forward = moveTo.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_EXPLOSION)
        {
            //lose
            Destroy(gameObject);
            _gm.Loose();
        }

        if (other.tag == Constants.TAG_EXIT)
        {
            //win
            _gm.Win();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
    }

    public void InstantiateBomb()
    {
        if (currentBombs > 0)
        {

            Vector3 pos = new Vector3(Mathf.Round(transform.position.x + transform.forward.x), Constants.BOMB_Y_POSITION, Mathf.Round(transform.position.z + transform.forward.z));
            if (_gm.boxes.Contains(pos) || Mathf.Abs(pos.x) > 7 || Mathf.Abs(pos.z) > 7)
            {
                pos = new Vector3(Mathf.Round(transform.position.x), Constants.BOMB_Y_POSITION, Mathf.Round(transform.position.z));
                transform.position = new Vector3(Mathf.Round(transform.position.x - transform.forward.x * 0.25f),
                                                             transform.position.y,
                                                 Mathf.Round(transform.position.z - transform.forward.z * 0.25f));
            }

            Bomb newBomb = Instantiate(prefabBomb, pos, Quaternion.identity).GetComponent<Bomb>();
            newBomb.range = rangeExplosion;
            currentBombs--;
        }
    }
}
