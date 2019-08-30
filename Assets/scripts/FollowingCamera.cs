using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
   
    private GameObject player;
    private float Speed = 5;
  
  
    void Start()
    {
        player = GameObject.Find("Player");
       

      //  transform.LookAt(point);
    }


    void Update()
    {



      

        
       
        
         transform.LookAt(player.transform.position+new Vector3(0,5,0));




    }
}
