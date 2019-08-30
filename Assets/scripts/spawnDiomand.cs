using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnDiomand : MonoBehaviour
{


    public GameObject[] diomands = new GameObject[6];


    int number = 10;

    void Start()
    {

        

        if (SceneManager.GetActiveScene().name == "game")
        {


            number = 8;
            // SceneManager.LoadScene("level2");

        }
        else if (SceneManager.GetActiveScene().name == "level2")
        {

            number = 15;
            // SceneManager.LoadScene("level3");

        }
        else if (SceneManager.GetActiveScene().name == "level3")
        {


            number = 20;
            // SceneManager.LoadScene("credit");

        }
        Debug.Log("elmas sayıs " +number);

        for (int i=0; i<number;i++)
        {


            int index = Random.Range(0,diomands.Length);



            GameObject dima = (GameObject)Instantiate(diomands[index], transform.position+new Vector3(Random.Range(-100,100),3.5f, Random.Range(-100, 100)) , Quaternion.identity);

            dima.transform.Rotate(-90, 0, 0, Space.Self);

        }
    }

    // Update is called once per frame
    void Update()
    {
        




    }
}
