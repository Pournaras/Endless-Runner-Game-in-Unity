using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject InstButton;
    public GameObject ExitButton;

    public GameObject Scroll;
    public GameObject Instructions1;
    public GameObject Instructions2;
    public GameObject OkButton;

    private bool isMuted;

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            isMuted = !isMuted;
            AudioListener.pause = isMuted;
            PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Time.timeScale = 1f;
        PauseManager.GameIsPaused = false;
    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
        PauseManager.GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        StartButton.SetActive(false);
        InstButton.SetActive(false);
        ExitButton.SetActive(false);

        Scroll.SetActive(true);
        Instructions1.SetActive(true);
        Instructions2.SetActive(true);
        OkButton.SetActive(true);
    }

    public void OK()
    {
        Scroll.SetActive(false);
        Instructions1.SetActive(false);
        Instructions2.SetActive(false);

        StartButton.SetActive(true);
        InstButton.SetActive(true);
        ExitButton.SetActive(true);

        OkButton.SetActive(false);
    }

}
