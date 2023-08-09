using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.getHurt();
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.2f)
        {
            float enemyAxisX = Random.Range(-8.5f, 8.5f);
            transform.position = new Vector3(enemyAxisX, 6.2f, 0);
        }
    }


}
