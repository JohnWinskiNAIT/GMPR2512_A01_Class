using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameState gameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene01")
        {
            gameState.score = 0;
        }

        UpdateScore();
    }

    [SerializeField] Button _scoreButton;
    [SerializeField] Label _scoreText;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _scoreButton = root.Q<Button>("ScoreButton");
        _scoreText = root.Q<Label>("ScoreText");

        if (_scoreButton != null)
        {
            _scoreButton.clicked += IncrementScore;
        }

        //if (_scoreText != null)
        //{
        //    _scoreText.text = gameState.score.ToString();
        //}
    }

    private void OnDisable()
    {
        if (_scoreButton != null)
        {
            _scoreButton.clicked -= IncrementScore;
        }
    }

    void IncrementScore()
    {
        gameState.score++;
        if (_scoreText != null)
        {
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        if (_scoreText != null)
        {
            _scoreText.text = gameState.score.ToString();
        }
    }
}
