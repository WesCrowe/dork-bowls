using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public int damage = 1;
    public float maxStamina = 200;
    public float stamina = 200;
    public int calories = 0;

    public StatBar HP;
    public StatBar ST;
    public CalorieCount CC;
    
    public Collider weapon;
    public Animator anim;
    public Transform spawnPoint;
    public PlayerAnimatorController playerAnim;

    // Update is called once per frame
    void Update()
    {
        if (!CheckIfAlive())
        {
            transform.position = spawnPoint.position;
            if ((calories -= 20) <= 0)
            {
                calories = 0;
            }
            
            //the quit doesn't do anything but yea
            //Application.Quit();
        }

        if (!isRolling() && !anim.GetCurrentAnimatorStateInfo(0).IsName("Slash Attack") && stamina < maxStamina)
        {
            stamina++;
        }
        else if (isRolling())
        {
            stamina -= 2f;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slash Attack"))
        {
            stamina -= 2f;
        }
        if (stamina < 0f)
        {
            stamina = 0f;
        }

        HP.SetVal(health / maxHealth);
        ST.SetVal(stamina / maxStamina);
        CC.SetVal(calories);
    }

    void Hit(Collider hitCollider)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slash Attack"))
        {
            EnemyInfo enemy = hitCollider.gameObject.GetComponent<EnemyInfo>();
            enemy.health -= damage;
            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }

    bool CheckIfAlive()
    {
        if (health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isRolling()
    {
        return playerAnim.isRolling();
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("calories", calories);
    }

    void OnEnable()
    {
        calories = PlayerPrefs.GetInt("calories");
    }
}
