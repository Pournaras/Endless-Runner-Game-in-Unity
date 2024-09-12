using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Text EndText;

    public GameObject RestartB;
    public GameObject GoBackB;
    public GameObject ExitB;
    public GameObject Scroll;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Resume()
    {
        GetComponent<AudioSource>().UnPause();
        Scroll.SetActive(false);
        EndText.text = "";
        RestartB.SetActive(false);
        GoBackB.SetActive(false);
        ExitB.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GetComponent<AudioSource>().Pause();
        Scroll.SetActive(true);
        EndText.text = "Παύση";
        RestartB.SetActive(true);
        GoBackB.SetActive(true);
        ExitB.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
}
