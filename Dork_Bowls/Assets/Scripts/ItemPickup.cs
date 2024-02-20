using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 45, 0) * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponent<PlayerInfo>().health += 30;
            other.gameObject.GetComponent<PlayerInfo>().maxHealth += 10;
            other.gameObject.GetComponent<PlayerInfo>().calories += 5;
            FindObjectOfType<AudioManager>().Play("ItemPickup");
        }
    }
}
