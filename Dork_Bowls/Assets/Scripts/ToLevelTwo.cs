using UnityEngine;
using UnityEngine.SceneManagement;


public class ToLevelTwo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 2 - Cake Citadel");
        }
    }
}
