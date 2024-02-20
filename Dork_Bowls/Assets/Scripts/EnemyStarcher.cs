using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarcher : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint; //Make empty firepoint where bullet starts
    private GameObject player;
    private Transform target;
    private float turnSpeed = 10f;

    public float fireRate = 2f;
    private float fireCountdown;

    public bool inRange = false;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(inRange)
        {
            target = player.transform;
        }

        if(target != null)
        {
            //Rotate to follow target
            Vector3 targetDir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDir);
            Vector3 rotationAngle = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotationAngle.y, 0f);
        }

        if(fireCountdown <= 0f && (target != null) && inRange)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletTemp = (GameObject)Instantiate(projectile, firePoint.position, firePoint.rotation);
        Projectile proj = bulletTemp.GetComponent<Projectile>();
        if(proj != null)
        {
            proj.Seek(target);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.transform.position.y + 10 >= transform.position.y)
            {
                inRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        gameObject.SetActive(false);
    }
}
