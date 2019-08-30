using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenü : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameisPause = false;
    // Update is called once per frame
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameisPause) {

                Resume();
            }
            else
            {

                Pause();
            }

        }
    }
     
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gameisPause=true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameisPause = false;
        Debug.Log("game resumed");
    }


    public void LoadMenu()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        Debug.Log("Qit  game");
        Application.Quit();
    }

    public void ReplayGame()
    {
        Debug.Log("replay game");
        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().name == "game")
        {


          
            SceneManager.LoadScene("game");

        }
        else if (SceneManager.GetActiveScene().name == "level2")
        {

         
            SceneManager.LoadScene("level2");

        }
        else if (SceneManager.GetActiveScene().name == "level3")
        {


            SceneManager.LoadScene("level3");

        }
    }
}
