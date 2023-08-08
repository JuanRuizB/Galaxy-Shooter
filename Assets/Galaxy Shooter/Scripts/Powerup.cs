using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField] private float _speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //access the player
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                //turn the triple shot bool to true
                player.TripleShotPowerupOn();
            }

            //destroy our selves
            Destroy(this.gameObject);
        }
    }
}
