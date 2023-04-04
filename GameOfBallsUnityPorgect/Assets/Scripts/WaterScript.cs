using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaterScript : MonoBehaviour
{



    public Slider slideWater;
    public Image fill;


    public void SetMaxWater(int Water)
    {
        slideWater.maxValue = Water;
        slideWater.value = Water;

   
    }

    public void setWater(int water)
    {
        slideWater.value = water;

    }

}
