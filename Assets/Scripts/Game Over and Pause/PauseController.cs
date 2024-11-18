using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Button resumeButton;
    public Button exitButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        exitButton.onClick.AddListener(Exit);
    }

    private void Resume()
    {
        AudioManager.Instance.Play(Sounds.ButtonClick);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void Exit()
    {
        AudioManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
