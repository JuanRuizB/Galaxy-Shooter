using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField] private float _speed = 2.0f;

    [SerializeField] private int _powerupID; // 0 = triple, 1 = speed, 2 = shield;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //access the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                //enable triple shot 
                if (_powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if (_powerupID == 1) //enable speed 
                {
                    player.SpeedBoostOn();
                }
                else if (_powerupID == 2) //enable shield
                {
                    player.ShieldPowerupOn();
                }

            }

            //destroy our selves
            Destroy(this.gameObject);
        }
    }
}
