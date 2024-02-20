using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCheese : MonoBehaviour
{

    private EnemyInfo cheese;

    // Start is called before the first frame update
    void Start()
    {
        cheese = GetComponent<EnemyInfo>();
        cheese.health = 15;
        cheese.maxHealth = 10;
        cheese.damage = 10;
        cheese.reward += 20;
    }
}
