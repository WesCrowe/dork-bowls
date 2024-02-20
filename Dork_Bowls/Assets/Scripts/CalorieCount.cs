using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalorieCount : MonoBehaviour
{
    //public Text calories;

    public void SetVal(int val)
    {
        GetComponent<Text>().text = " Calories: "+val;
    }
}
