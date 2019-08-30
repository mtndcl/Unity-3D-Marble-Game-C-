using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{




    public GameObject[] eggs = new GameObject[3];

    Player playerdata;
    void Start(){

        GameObject pp = GameObject.Find("Player");
        playerdata = pp.GetComponent<Player>();

        for(int i = 0; i < playerdata.level*3; i++)
        {
            Spawn();
        }

        InvokeRepeating("Spawn", 2.0f, (10-playerdata.level*3));

       
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }

    void Spawn() {


        int index = Random.Range(0, 3);


        Vector3 location = new Vector3(Random.Range(-100, 100), Random.Range(0, 5), Random.Range(-100, 100));
        GameObject enemy = (GameObject)Instantiate(eggs[index], transform.position + location, Quaternion.identity);

        enemy data = enemy.GetComponent<enemy>();
        // transform.position = Random.insideUnitCircle * 5;
        

       

        switch (index)
        {


            case 0:
                data.damage = 15;
                data.Maximunthealth = 24.0f;
                data.Currenthealth = data.Maximunthealth;
                data.movementSpeed = 15;
                break;
            case 1:
                data.damage = 25;
                data.Maximunthealth = 74.0f;
                data.Currenthealth = data.Maximunthealth;
                data.movementSpeed =10;
                break;
            case 2:
                data.damage = 30;
                data.Maximunthealth = 124.0f;
                data.Currenthealth = data.Maximunthealth;
                data.movementSpeed = 8 ;
                break;

        }
    }
}
