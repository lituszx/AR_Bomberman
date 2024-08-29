using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public  BoxGift             power;
    private PlayerController    _player;

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Constants.TAG_PLAYER)
        {
            switch (power)
            {
                case BoxGift.SPEED:
                    _player.speed = _player.speed + 1;    
                    break;
                case BoxGift.RANGE:
                    _player.rangeExplosion++;
                    break;
                case BoxGift.BOMB:
                    _player.currentBombs++;
                    break;
            }
            Destroy(gameObject);
        }   
    }
}
