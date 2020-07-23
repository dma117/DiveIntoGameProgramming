using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.SetActive(false);
        SetScore(0);
        UpdateLives(3); 
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
        _gameOverText.SetActive(true);
    }
}
