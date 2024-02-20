using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed;
    public PlayerInfo player;
    public GameObject splashEffect;
    private Vector3 dir;

    public void Seek(Transform newTarget)
    {
        target = newTarget;
        //targeting
        Vector3 randomMod = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        dir = target.position - transform.position;
        dir += randomMod;
        FindObjectOfType<AudioManager>().Play("StarcherAttack");

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            float distanceInFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceInFrame, Space.World);
            if(dir.magnitude <= distanceInFrame)
            {
                HitTarget();
                return;
            }
        }

    }

    private void HitTarget()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(splashEffect, transform.position, transform.rotation);
            player = other.gameObject.GetComponent<PlayerInfo>();
            FindObjectOfType<AudioManager>().Play("HitByStarcher");
            if (player.health > 0)
            {
                player.health -= 10f;
            }
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        //to allow it to go through safety colliders
        else if (other.gameObject.tag == null)
        {
            return;
        }
        else if (other.gameObject.tag == "barrier")
        {
            return;
        }

        //gameObject.SetActive(false);
        //Destroy(gameObject);
        return;

    }
}
