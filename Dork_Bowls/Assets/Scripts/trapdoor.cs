using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor : MonoBehaviour
{
    private GameObject bigcheese;
    private Animation anim;
    private bool activate = true;

    // Start is called before the first frame update
    void Start()
    {
        bigcheese = GameObject.Find("Big Cheese");
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bigcheese.activeSelf && activate)
        {
            AnimPlayer();
            activate = false;
        }
    }

    void AnimPlayer()
    {
        anim.Play();
    }
}
