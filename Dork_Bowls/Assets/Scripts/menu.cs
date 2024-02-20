using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class menu : MonoBehaviour
{
    GraphicRaycaster menuRaycast;
    PointerEventData menuPED;
    EventSystem menuES;

    void Start()
    {
        menuRaycast = GetComponent<GraphicRaycaster>();
        menuES = GetComponent<EventSystem>();

        PlayerPrefs.SetInt("calories", 0);
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse0))
        {
            menuPED = new PointerEventData(menuES);
            menuPED.position = Input.mousePosition;
            
            //list of raycast results
            List<RaycastResult> results = new List<RaycastResult>();
            menuRaycast.Raycast(menuPED, results);

            //check the returned result for its button, execute proper result
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "StartButton")
                {
                    SceneManager.LoadScene("Info Screen");
                }

                else if (result.gameObject.name == "QuitButton")
                {
                    Application.Quit();
                }
            }
        }
    }
}