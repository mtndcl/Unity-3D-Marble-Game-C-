using UnityEngine;
using UnityEngine.UI;
public class EnemyFollowPlayer : MonoBehaviour
{
    private GameObject Player;
    public float movementSpeed = 4;


    public Slider health;
    

    private void Start()
    {

         
         Player = GameObject.Find("Player");

        health.value = 1.0f;
       
    }
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

  
}
