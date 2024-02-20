using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBowldwinInfo : MonoBehaviour
{

    private EnemyInfo king;

    // Start is called before the first frame update
    void Start()
    {
        king = gameObject.GetComponent<EnemyInfo>();
        king.health = 50;
        king.maxHealth = 50;
        king.damage = 20;
        king.reward += 1730;
    }
}
