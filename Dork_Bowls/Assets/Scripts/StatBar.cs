using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Slider slider;

    public void SetVal(float val)
    {
        slider.value = val;
    }
}
