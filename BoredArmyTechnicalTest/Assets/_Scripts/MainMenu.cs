using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject _mainPanel;
    public GameObject _settingsPanel;
    public Slider _gameDurationSlider;
    public Slider _enemySpawnRateSlider;
    public Text _gameDurationText;
    public Text _enemySpawnRateText;

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.StartGame();
    }

    public void SettingsButton()
    {
        _mainPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void ReturnButton()
    {
        _mainPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }

    public void SetGameDuration()
    {
        PlayerPrefs.SetInt("Game Duration", (int)_gameDurationSlider.value);
        _gameDurationText.text = "Duração da partida(s): " + _gameDurationSlider.value.ToString();
    }

    public void SetEnemyRespawnRate()
    {
        PlayerPrefs.SetFloat("Enemy Spawn Rate", _enemySpawnRateSlider.value);
        _enemySpawnRateText.text = "Tempo de spawn dos inimigos(s): " + _enemySpawnRateSlider.value.ToString("F1");
    }
}
