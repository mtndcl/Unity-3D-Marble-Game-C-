using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{


    private GameObject player;


    public float damage;
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 100)
        {
            Destroy(gameObject);

        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "enemy0")
        {
            enemy en = other.gameObject.GetComponent<enemy>();

            Debug.Log("enemy max live  "+en.Maximunthealth +"  curent live "+en.Currenthealth);

            GameObject ChildGameObject1 = other.transform.GetChild(1).gameObject;
            GameObject ChildGameObject2 = ChildGameObject1.transform.GetChild(0).gameObject;


            Slider ha = ChildGameObject2.GetComponent<Slider>();


          
            en.Currenthealth -= damage;

            ha.value = en.Currenthealth / en.Maximunthealth;


            if (en.Currenthealth<0)
            {
                Destroy(other.gameObject);

            }
            Destroy(this.gameObject);



        }
        else if (other.tag == "aroundobject")
        {
            Destroy(this.gameObject);
            print("bullet touch envirement");
        }
      


    }

}

