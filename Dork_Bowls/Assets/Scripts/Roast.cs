using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roast : MonoBehaviour
{
    public PlayerInfo player;
    public GameObject roastText;
    public new GameObject light;
    public GameObject spark;
    public GameObject flame;
    public bool lit = false;


    private void Start()
    {
        roastText.SetActive(false);
        light.SetActive(false);
        spark.SetActive(false);
        flame.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && lit == false)
        {
            roastText.SetActive(true);

        }
        if (lit == true)
        {
            FindObjectOfType<AudioManager>().Play("Fire");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player = other.gameObject.GetComponent<PlayerInfo>();
                player.spawnPoint.transform.position = other.transform.position;
                roastText.SetActive(false);
                light.SetActive(true);
                spark.SetActive(true);
                flame.SetActive(true);
                lit = true;
                FindObjectOfType<AudioManager>().Play("Fire");

            }
            if(lit == true && player.health < player.maxHealth)
            {
                player.health += 0.5f;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            roastText.SetActive(false);
            FindObjectOfType<AudioManager>().StopPlaying("Fire");
        }
    }
}
