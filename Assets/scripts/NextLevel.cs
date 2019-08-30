using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class NextLevel : MonoBehaviour
{
    Player playerdata;
    private void Start()
    {
        GameObject pp = GameObject.Find("Player");
        playerdata = pp.GetComponent<Player>();
    }
    public void ClickOnNextLevel()
    {


        if (SceneManager.GetActiveScene().name=="game")
        {


            playerdata.level = 1;
            SceneManager.LoadScene("level2");

        }
        else if (SceneManager.GetActiveScene().name == "level2")
        {

            playerdata.level = 2;
            SceneManager.LoadScene("level3");

        }
        else if (SceneManager.GetActiveScene().name == "level3")
        {


            playerdata.level = 3;
            SceneManager.LoadScene("credit");

        }

    }
}
