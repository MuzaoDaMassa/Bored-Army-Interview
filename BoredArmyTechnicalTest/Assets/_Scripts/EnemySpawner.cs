using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] _enemies;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(1.0f);

        while (!GameManager._isGameOver)
        {
            int enemyToSpawn = Random.Range(0, 2);
            Instantiate(_enemies[enemyToSpawn], this.transform.position, Quaternion.identity, this.transform);
            Debug.Log(GameManager._enemySpawnRate.ToString());
            yield return new WaitForSeconds(GameManager._enemySpawnRate);
        }
    }
}
