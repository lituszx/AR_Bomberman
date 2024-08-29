using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float                speed;
    public int                  range;
    public GameObject           prefabExplosion;

    private Vector3             localScale;
    private float               time;
    private GameManager         _gm;
    private ParticleSystem      _p;
    private PlayerController    _player;
    private int[]               _range = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        _gm         = GameObject.FindObjectOfType<GameManager>();
        _player     = GameObject.FindObjectOfType<PlayerController>();
        time        = 0;
        localScale  = transform.localScale;

        Invoke("InstantiateExplosions", Constants.EXPLOSION_TIME);
        Destroy(gameObject, Constants.DESTROY_EXPLOSION_TIME);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        transform.localScale = localScale +  Vector3.one * localScale.x * Constants.INCREMENT_BOMB_ANIMATION * (1 + Mathf.Sin(time));
    }


    void InstantiateExplosions()
    {
        this.enabled = false;
        transform.localScale = localScale + Vector3.one;

        GetComponent<MeshRenderer>().enabled = false;
        Instantiate(prefabExplosion, transform.position, Quaternion.identity, transform);
        CalculateRange(Direction.RIGHT,  1,   0);
        CalculateRange(Direction.LEFT,  -1,   0);
        CalculateRange(Direction.UP,     0,   1);
        CalculateRange(Direction.DOWN,   0, - 1);

        
        _player.currentBombs++;
    }


    private void CalculateRange(Direction dir, int x, int z)
    {
        for (int i = 1; i <= range; i++)
        {
            Vector3 pos = transform.position;
            pos = new Vector3(pos.x + (x * i), Constants.BOMB_Y_POSITION, pos.z + (z * i));
            if (_gm.IsOutOfBricks(pos) || _gm.IsOutOfBoxes(pos))
            {
                if(_gm.IsOutOfBoxes(pos))
                    Instantiate(prefabExplosion, pos, Quaternion.identity, transform);
                return;
            }
            else
            {
                Instantiate(prefabExplosion, pos, Quaternion.identity, transform);
            }
        }

    }

}
