using UnityEngine;

public class ProjectileBoss : MonoBehaviour
{
    private Transform target;
    public float speed;
    public PlayerInfo player;
    public GameObject soupLava;
    private Vector3 dir;

    public void Seek(Transform newTarget)
    {
        target = newTarget;
        //targeting
        Vector3 randomMod = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        dir = target.position - transform.position;
        dir += randomMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            float distanceInFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceInFrame, Space.World);
            if (dir.magnitude <= distanceInFrame)
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
            player = other.gameObject.GetComponent<PlayerInfo>();
            if (player.health > 0)
            {
                player.health -= 10f;
            }
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        else if (other.gameObject.CompareTag("ProjDestroyer"))
        {
            Instantiate(soupLava, transform.position, transform.rotation);
            return;
        }
        return;

    }
}
