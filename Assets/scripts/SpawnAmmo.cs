using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAmmo : MonoBehaviour
{
    
    public GameObject ammomprefab;
    void Start()
    {

        int level = gamelevel();
                

        for (int i = 0; i <level * 5; i++)
        {






            GameObject dima = (GameObject)Instantiate(ammomprefab, transform.position + new Vector3(Random.Range(-100, 100), 3.5f, Random.Range(-100, 100)), Quaternion.identity);



        }
    }


    private  int gamelevel()
    {


        if (SceneManager.GetActiveScene().name == "game")
        {


            return 1;
           

        }
        else if (SceneManager.GetActiveScene().name == "level2")
        {

            return 2;

        }
        else if (SceneManager.GetActiveScene().name == "level3")
        {



            return 3;

        }

        return 1;

    }
}
