using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bulletTriggered : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;


    void Start()
    {


        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(transform.position,player.transform.position)>100)
        {
            Destroy(gameObject);

        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "enemy0")
        {

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "enemy1") {

            GameObject ChildGameObject1 = other.transform.GetChild(1).gameObject;
            GameObject ChildGameObject2 = ChildGameObject1.transform.GetChild(0).gameObject;


            Slider ha = ChildGameObject2.GetComponent<Slider>();
            ha.value -= 0.4f;
            if (ha.value<0.1f)
            {
                Destroy(other.gameObject);

            }


        }
        else if (other.tag == "enemy2")
        {

            GameObject ChildGameObject1 = other.transform.GetChild(1).gameObject;
            GameObject ChildGameObject2 = ChildGameObject1.transform.GetChild(0).gameObject;


            Slider ha = ChildGameObject2.GetComponent<Slider>();
            ha.value -= 0.2f;
            if (ha.value < 0.1f)
            {
                Destroy(other.gameObject);

            }


        }
        else if (other.tag == "box"){

            Destroy(this.gameObject);

        }
        Destroy(this.gameObject);

    }
}
