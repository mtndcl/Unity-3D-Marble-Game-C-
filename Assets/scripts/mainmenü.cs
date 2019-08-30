using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenü : MonoBehaviour
{


   
    public void PLayGame()
    {

       


        SceneManager.LoadScene("game");

    }

    public void QuittGame()
    {

        Application.Quit();
         
    }
}
