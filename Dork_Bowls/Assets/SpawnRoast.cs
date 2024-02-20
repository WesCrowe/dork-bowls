using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoast : MonoBehaviour
{

    public GameObject roast;
    public GameObject bigCheese;
    private bool activate = true;

    // Start is called before the first frame update
    void Start()
    {
        roast.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bigCheese.activeSelf && activate)
        {
            roast.SetActive(true);
            activate = false;
        }
    }
}
