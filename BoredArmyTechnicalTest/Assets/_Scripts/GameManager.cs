using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager 
{
    public static bool _isGameOver = false;
    public static int _gameDuration = PlayerPrefs.GetInt("Game Duration", 60);
    public static float _enemySpawnRate = PlayerPrefs.GetFloat("Enemy Spawn Rate", 3.5f);
    public static int _score = 0;

    public static void StartGame()
    {
        _isGameOver = false;
        _gameDuration = PlayerPrefs.GetInt("Game Duration", 60);
        _enemySpawnRate = PlayerPrefs.GetFloat("Enemy Spawn Rate", 3.5f);
        _score = 0;
    }
}
