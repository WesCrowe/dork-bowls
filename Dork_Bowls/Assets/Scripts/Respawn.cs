using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawn;
    public PlayerInfo playerInfo;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn = new Vector3(0, 26, -20);
            other.transform.position = respawn;
            other.transform.rotation = new Quaternion(0, 0, 0, 0);
            if (playerInfo != null)
            {
                playerInfo.health -= playerInfo.health;
            }
        }
    }
}
