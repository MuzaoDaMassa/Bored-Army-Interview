using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] _enemies;

    private float _spawnRangeX;
    private float _spawnRangeY;


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
            Instantiate(_enemies[enemyToSpawn], PositionToSpawn(), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(GameManager._enemySpawnRate);
        }
    }

    private Vector2 PositionToSpawn()
    {
        _spawnRangeX = Random.Range(-15f, 15f);
        _spawnRangeY = Random.Range(-10f, 10f);

        if (_spawnRangeX >= 7.5f && _spawnRangeX <= 12.2f)
        {
            if (_spawnRangeY >= 1.4f && _spawnRangeY <= 6.0f)
            {
                return new Vector2(_spawnRangeX - Random.Range(3.5f, 5f), _spawnRangeY - Random.Range(3.5f, 5f));
            }
            else
            {
                return new Vector2(_spawnRangeX, _spawnRangeY);
            }

        }
        else if (_spawnRangeX <= -8f && _spawnRangeX >= -12.5)
        {
            if (_spawnRangeY <= -2.5 && _spawnRangeY >= -6.5f )
            {
                return new Vector2(_spawnRangeX + Random.Range(3.5f, 5f), _spawnRangeY + Random.Range(3.5f, 5f));
            }
            else
            {
                return new Vector2(_spawnRangeX, _spawnRangeY);
            }
        }
        else
        {
            return new Vector2(_spawnRangeX, _spawnRangeY);
        }
    }
}
