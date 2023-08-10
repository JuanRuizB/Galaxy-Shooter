using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    //public void updateSpawn()
    //{
    //    if (!isSpawn)
    //    {
    //        StartCoroutine(EnemySpawnRoutine());
    //        StartCoroutine(PowerupSpawnRoutine());
    //    }
    //    else
    //    {
    //        StopAllCoroutines();
    //        Destroy(enemyShipPrefab);
    //        Destroy(powerups[0]);
    //        Destroy(powerups[1]);
    //        Destroy(powerups[2]);
    //    }
    //    isSpawn = !isSpawn;
    //}

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 6.2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }


    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-8.5f, 8.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }

    }

}
