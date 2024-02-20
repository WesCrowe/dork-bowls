using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupLava : MonoBehaviour
{
    public PlayerInfo player;
    public GameObject boilSound;
    private float lifetime = 5f;

    public GameObject thisSound;

    private void Awake()
    {
        thisSound = (GameObject)Instantiate(boilSound, transform.position, transform.rotation);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerInfo>();
            if (player.health > 0)
            {
                player.health -= 0.2f;
            }
        }
    }

    private void Update()
    {
        if (lifetime <= 0f)
        {
            Destroy(thisSound);
            Destroy(gameObject);
            return;
        }
        lifetime -= Time.deltaTime;
    }
}
