using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyInfo : MonoBehaviour
{
    public Animator anim;
    public float health = 10f;
    public float maxHealth = 10f;
    public int damage = 10;
    public PlayerInfo player;
    public GameObject healthUI;
    public Slider slider;
    public int reward = 10;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInfo>();
        healthUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            player.calories += reward;
            gameObject.SetActive(false);
        }
        slider.value = (health / maxHealth);
        if(health < maxHealth)
        {
            healthUI.SetActive(true);
        }
    }

    void Hit(Collider hitCollider)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slam"))
        {
            PlayerInfo player = hitCollider.gameObject.GetComponent<PlayerInfo>();
            if (!player.isRolling())
            {
                player.health -= damage;
                FindObjectOfType<AudioManager>().Play("HitByCheese");
            }
        }
    }
}
