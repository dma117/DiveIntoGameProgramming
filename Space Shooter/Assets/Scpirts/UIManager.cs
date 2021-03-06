﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private GameObject _sceneManager;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    
    void Start()
    {
        _gameOverText.SetActive(false);
        _restartText.gameObject.SetActive(false);
        SetScore(0);
        UpdateLives(3); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _restartText.gameObject.activeSelf)
        {
            _sceneManager.GetComponent<SceneController>().UpdateScene();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenuPanel.gameObject.SetActive(true);
        }
    }

    public void SetScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLive)
    {
        _livesImg.sprite = _liveSprites[currentLive];
    }

    public void GameOver()
    {
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            _gameOverText.SetActive(false);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
