using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour
{
    // Update is called once per frame
    void OnEnable()
    {
        //max Calories: 2200
        GetComponent<Text>().text = PlayerPrefs.GetInt("calories")+"/2200";
    }
}
