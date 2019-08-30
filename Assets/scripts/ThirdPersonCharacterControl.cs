using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    private int level = 1;

    private float Speed=5;


    private float rotatepeed = 50.0f;

    public GameObject player;

    private Rigidbody rb;

    private bool isground=false;


    private Vector3 offset;

    private float a = 0.1f;


    private GameObject point;


    public TMP_Text diomnadsText;

    private int numberdiomand=0;

    public Slider healtbar;

    private float Currenthealth { get; set; }
    private float Maximunthealth { get; set; }

    public GameObject finishpanel;


    public GameObject youwinpanel   ;

    private bool gameover = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        diomnadsText.text = numberdiomand.ToString() + "/" + (level*5).ToString();
        offset = transform.position - player.transform.position;

        Maximunthealth = 100f;
        Currenthealth = Maximunthealth;
        healtbar.value = Currenthealth / Maximunthealth;

    }
    void Update ()
    {


        if (!gameover)
        {


            if (Math.Abs(player.transform.position.x) > 100 || Math.Abs(player.transform.position.z) > 100)
            {

                gameover = true;
                Gameover();
            }
        }

        /*

        
           if (Math.Abs(player.transform.position.x )>100  || Math.Abs(player.transform.position.z) > 100)
         {

             Gameover();
         }*/

      
        PlayerMovement();
    }

    private void Gameover()
    {
        Time.timeScale = 0.0f;
        finishpanel.SetActive(true);
    }

    void PlayerMovement()
    {
        ///////////
        ///Camera
        transform.position = player.transform.position + offset;

        transform.LookAt(player.transform.position);

        //Vector3 p = player.transform.position;
        //Vector3 b = point.transform.position;
        float moveVertical = Input.GetAxis("Horizontal"); 
        float moveHorizontal = Input.GetAxis("Vertical"); 

         Vector3 newPosition = new Vector3(-moveHorizontal, 0.0f, moveVertical);
        newPosition = transform.TransformDirection(newPosition);
        transform.Translate(newPosition * 10 * Time.deltaTime, Space.World);







        if (isground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("player send command to jump");
                rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            }

        }

       
        
          player.transform.Rotate(0, Input.GetAxis("Mouse X") *100 * Time.deltaTime, 0);
       

    }

    private void OnTriggerEnter(Collider other)
    {

       // print("player start stay on ground");
        if (other.tag=="plane") {
            isground = true;
            
        }
        else if (other.tag == "diamondo")
        {
           

            Destroy(other.gameObject);
            numberdiomand++;
            diomnadsText.text = numberdiomand.ToString() + "/" + (level*5).ToString();


            if (numberdiomand==level*5)
            {
                youwinpanel.SetActive(true);

            }

        }else if (other.tag == "enemy0"  || other.tag == "enemy1" || other.tag == "enemy2")
        {

            KillEnemy(other);
        }
    }

    private void KillEnemy(Collider other)
    {


        //   GameObject  enemy=  other.gameObject.GetComponent<SpawnEnemy>();
     //  print("bak oglum "+other.gameObject.GetComponent<EnemyFollowPlayer>().damage);
        
        healtbar.value = Currenthealth / Maximunthealth;

      


        if (Currenthealth<0)
        {

            Gameover();

        }
    }

    private void OnTriggerExit(Collider other)
    {

        //print("jumpıng");
        if (other.tag == "plane")
        {
            isground = false;

        }
        
    }
}