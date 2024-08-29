using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject[] prefabs;
    public BoxGift      gift;
    private GameManager _gm;

    // Start is called before the first frame update

    private void Awake()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();    
    }

    public void InstatiatePowerUp()
    {
        Vector3 pos = transform.position;
        pos.y = Constants.POWERUP_Y_POSITION;
        Instantiate(prefabs[(int)gift], pos, Quaternion.Euler(90,0,0));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_EXPLOSION)
        {
            if (gift != BoxGift.NONE)
                InstatiatePowerUp();

            _gm.AddPoints(Constants.KILL_BOX_POINTS);
            _gm.RemoveBox(transform.position);
            Destroy(gameObject);
        }
    }
}
