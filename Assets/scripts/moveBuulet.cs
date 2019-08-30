using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moveBuulet : MonoBehaviour
{
    // Start is called before the first frame update





    public GameObject player;


    public GameObject bulletpoint;

    public GameObject bullet;

    private int bulletnumber = 10;


    public TMP_Text bulletText;
    void Start()
    {

        bulletText.text = bulletnumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {


            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();

            Vector3 p = player.transform.position;
            Vector3 b = bulletpoint.transform.position;

            rigidbody.AddForce((b - p) * 20, ForceMode.Impulse);
            bulletnumber--;

            bulletText.text =bulletnumber.ToString();

        }

    }
}
