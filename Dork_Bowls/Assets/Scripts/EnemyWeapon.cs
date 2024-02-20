using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public EnemyInfo enemy;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            enemy.SendMessage("Hit", other);
        }
    }
}