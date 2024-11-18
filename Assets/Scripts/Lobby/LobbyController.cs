using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public Button aboutButton;
    public Button exitButton;

    public GameObject aboutinfo;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        aboutButton.onClick.AddListener(About);
        exitButton.onClick.AddListener(Exit);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
        AudioManager.Instance.Play(Sounds.ButtonClick);
    }
    private void About()
    {
        aboutinfo.SetActive(!aboutinfo.activeInHierarchy);
        AudioManager.Instance.Play(Sounds.ButtonClick);
    }
    private void Exit()
    {
        AudioManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
