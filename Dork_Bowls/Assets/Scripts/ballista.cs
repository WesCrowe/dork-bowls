using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballista : MonoBehaviour
{
    public PlayerInfo player;
    public GameObject projectile;
    public GameObject BallistaText;
    private GameObject bulletTemp;
    public Transform firePoint;
    public Transform target;
    public EnemyStarcher starcher;
    private Animation anim;
    private bool NotUsed = true;

    // Start is called before the first frame update
    void Start()
    {
        BallistaText.SetActive(false);
        anim = gameObject.GetComponent<Animation>();
        player = GameObject.Find("Player").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BallistaText.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && NotUsed)
        {
            //launch projectile:
            Shoot();

            //disable ballista:
            AnimPlayer();
            NotUsed = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            BallistaText.SetActive(false);

            //give calories for kill
            player.calories += 10;
        }
    }

    private void Shoot()
    {
        bulletTemp = (GameObject)Instantiate(projectile, firePoint.position, firePoint.rotation);
        Projectile proj = bulletTemp.GetComponent<Projectile>();
        if (proj != null)
        {
            proj.Seek(target);
        }
        Invoke("destroyArcher", 0.7f);

    }

    private void destroyArcher()
    {
        starcher.gameObject.SetActive(false);
        Destroy(bulletTemp);
        return;
    }

    void OnTriggerExit(Collider other)
    {
        BallistaText.SetActive(false);
    }

    void AnimPlayer()
    {
        anim.Play();
    }
}
