using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class KingController : MonoBehaviour
{
    private Rigidbody rb;
    private UnityEngine.AI.NavMeshAgent agent;
    public EnemyInfo enemyInfo;
    private Transform target = null;

    private float jumpForce;
    private int frame;
    private bool playing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        jumpForce = 5f;
        frame = 0;
    }

    void Update()
    {
        if(enemyInfo.health <= 0)
        {
            FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
            SceneManager.LoadScene("End Scene");
        }
        if (TargetAcquired())
        {
            if (agent.enabled == true && !agent.pathPending && agent.remainingDistance < 5f)
            {
                GoToPoint(target);
            }
            if (frame == 420)
            {
                agent.enabled = false;
                rb.AddForce(rb.velocity + new Vector3(1f, jumpForce, 1f));
            }
            else if (frame == 420 + 180)
            {
                agent.enabled = true;
                frame = 0;
            }
            frame++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if collider is player then make target
        if (other.gameObject.CompareTag("Player"))
        {
            if(playing == false)
            {
                playing = true;
                FindObjectOfType<AudioManager>().Play("BossMusic");
            }

            target = other.gameObject.transform;
        }
    }

    bool TargetAcquired()
    {
        if (target == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void GoToPoint(Transform target)
    {
        float distance2Target = Vector3.Distance(target.position, transform.position);
        if (distance2Target > 6.8f && agent.enabled == true)
        {
            agent.destination = target.position;
        }
    }
}
