using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBoss : MonoBehaviour
{

    public GameObject player;
    public GameObject bossSpawn;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().StopPlaying("Music");
                player.transform.position = bossSpawn.transform.position;
                player.transform.rotation = bossSpawn.transform.rotation;
            }
        }
    }
}
