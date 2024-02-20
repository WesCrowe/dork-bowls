using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target = null;
    private float range = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
    }

    void Update()
    {
        if (target != null)
        {
            //Rotate to follow target
            Vector3 targetDir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDir);
            Vector3 rotationAngle = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotationAngle.y, 0f);
        }

        if (TargetAcquired())
        {
            float distance2Target = Vector3.Distance(target.position, transform.position);
            if (distance2Target > 20f)
            {
                target = null;
            }
            if (distance2Target <= agent.stoppingDistance + range)
            {
                anim.SetInteger("Attack1", 1);
            }
            else
            {
                anim.SetInteger("Attack1", 0);
            }
        }
        if (!agent.pathPending && agent.remainingDistance < 5f && TargetAcquired() && !anim.GetCurrentAnimatorStateInfo(0).IsName("Slam"))
        {
            GoToPoint(target);
        }
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    void OnTriggerEnter(Collider other)
    {
        //if collider is player then make target
        if (other.gameObject.CompareTag("Player"))
        {
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
        if (distance2Target > 2.5f)
        {
            agent.destination = target.position;
        }
    }
}