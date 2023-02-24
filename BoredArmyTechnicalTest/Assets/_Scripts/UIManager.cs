using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _timeText;

    public GameObject _gameOverScreen;

    private void Start()
    {
        StartCoroutine(GameClock());
    }

    private void Update()
    {
        _scoreText.text = "Pontos: " + GameManager._score.ToString();
        _timeText.text = "Tempo: " + GameManager._gameDuration.ToString();
    }

    private IEnumerator GameClock()
    {
        while (!GameManager._isGameOver)
        {
            if (GameManager._gameDuration <= 0)
            {
                GameManager._isGameOver = true;
                _gameOverScreen.SetActive(true);
                yield return null;
            }
            else
            {
                GameManager._gameDuration--;
                yield return new WaitForSeconds(1.0f);
            }
        }
        _gameOverScreen.SetActive(true);
    }
}
