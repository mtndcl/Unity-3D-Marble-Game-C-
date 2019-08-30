using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public int level;






    private GameObject player;

    private Rigidbody rb;

    private bool isground = false;


    private Vector3 offset;






    //public TMP_Text diomnadsText;



    public Slider healtbar;

    private float Currenthealth { get; set; }
    private float Maximunthealth { get; set; }



    private bool gameover = false;

    public GameObject bulletprefab;

    public GameObject bulletpoint;


    private int bulletnumber;
    private int diomandnumber = 0;
    public TMP_Text bullettext;
    public TMP_Text diomandtext;


    public GameObject finishpanel;


    public GameObject youwinpanel;


    public AudioSource[] sounds = new AudioSource[10];

    private float speed = 10.0f;

    public GameObject showpowerpanel;

    public Slider powerslide;

    private float powerinitime;

    private float powerpassedtime;

    private bool power = false;


    public TMP_Text powerText;


    private void Start()
    {



        SetLevel();

        bulletnumber = 20 * level;
        diomandtext.text = diomandnumber.ToString() + " / " + (level * 5).ToString();
        bullettext.text = bulletnumber.ToString();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();

        offset = transform.position - player.transform.position;

        Maximunthealth = 100f;
        Currenthealth = Maximunthealth;
        healtbar.value = Currenthealth / Maximunthealth;

        powerinitime = Time.time;
        showpowerpanel.SetActive(false);
    }

    public void SetLevel()
    {

        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().name == "game")
        {


            level = 1;
            // SceneManager.LoadScene("level2");

        }
        else if (SceneManager.GetActiveScene().name == "level2")
        {

            level = 2;
            // SceneManager.LoadScene("level3");

        }
        else if (SceneManager.GetActiveScene().name == "level3")
        {


            level = 3;
            // SceneManager.LoadScene("credit");

        }
    }

    void Update()
    {


        if (power)
        {
            powerpassedtime = Time.time - powerinitime;
            if (powerpassedtime < 5)
            {

                Debug.Log("passed time " + powerpassedtime + " bar value " + powerslide.value);
                powerslide.value = (5 - powerpassedtime) / 5;
                powerText.text = "SPEED UP FOR " + String.Format("{0:0.00}", (5 - powerpassedtime)) + " SECONDS";

            }
            else
            {

                power = false;
                showpowerpanel.SetActive(false);
                speed = 10;
            }



        }

        CheckGameOver();


        PlayerMovement();


        Fire();
    }

    private void CheckGameOver()
    {

        if (!gameover)
        {


            if (Math.Abs(player.transform.position.x) > 100 || Math.Abs(player.transform.position.z) > 100)
            {

                gameover = true;
                Gameover();
            }
        }

    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F) && bulletnumber > 0)
        {




            sounds[0].Play();
            GameObject instBullet = Instantiate(bulletprefab, transform.position, Quaternion.identity);

            Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();

            Vector3 p = player.transform.position;
            Vector3 b = bulletpoint.transform.position;

            rigidbody.AddForce((b - p) * 20, ForceMode.Impulse);


            Bullet s = instBullet.GetComponent<Bullet>();

            s.damage = 25;

            bulletnumber--;

            bullettext.text = bulletnumber.ToString();

        }
    }

    private void Gameover()
    {
        showpowerpanel.SetActive(false);
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
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);







        if (isground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("player send command to jump");
                sounds[3].Play();
                rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            }

        }



        player.transform.Rotate(0, Input.GetAxis("Mouse X") * 100 * Time.deltaTime, 0);


    }

    private void OnTriggerEnter(Collider other)
    {

        // print("player start stay on ground");

        if (other.tag == "diamondo")
        {

            sounds[1].Play();


            Destroy(other.gameObject);
            diomandnumber++;
            diomandtext.text = diomandnumber.ToString() + " / " + (level * 5).ToString();


            if (diomandnumber == level * 5)
            {

                showpowerpanel.SetActive(false);
                youwinpanel.SetActive(true);
               
                Time.timeScale = 0.0f;
            }

        }
        else if (other.tag == "enemy0")
        {
            sounds[2].Play();
            EnemyAtackUS(other);
        }
        else if (other.tag == "flash")
        {
            speed += 10;
            powerinitime = Time.time;
            power = true;
            showpowerpanel.SetActive(true);

          

            Destroy(other.gameObject);
        }
        else if (other.tag == "ammo")
        {

            sounds[4].Play();
            bulletnumber += 10;
            bullettext.text = bulletnumber.ToString();
            Destroy(other.gameObject);
        }
        else
        {
            isground = true;

        }
    }

    private void EnemyAtackUS(Collider other)
    {


        enemy en = other.gameObject.GetComponent<enemy>();

        Currenthealth -= en.damage;

        healtbar.value = Currenthealth / Maximunthealth;




        if (Currenthealth < 0)
        {

            Gameover();

        }
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        Vector3 p = player.transform.position;
        Vector3 b = bulletpoint.transform.position;

        rb.AddForce((b - p) * 10, ForceMode.Impulse);
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
