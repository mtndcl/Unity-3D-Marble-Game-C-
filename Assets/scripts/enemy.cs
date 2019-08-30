using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class enemy : MonoBehaviour
{
    private GameObject Player;
    public float movementSpeed = 4;


    public Slider health;


    public float Currenthealth { get; set; }
    public float Maximunthealth { get; set; }


    public float damage;

    
    private void Start()
    {


        Player = GameObject.Find("Player");

        health.value = 1.0f;

    }
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

        if (Math.Abs(transform.position.x) > 100 || Math.Abs(transform.position.z) > 100)
        {

            Destroy(this);
        }
    }

}
