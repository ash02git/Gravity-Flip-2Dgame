using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalscoreText;
    public Button restartButton;
    public Button exitButton;

    public ScoreController scoreController;

    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
    }
    private void Start()
    {
        finalscoreText.text = "Final Score : " + scoreController.GetScore();
    }

    private void Restart()
    {
        AudioManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Exit()
    {
        AudioManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
