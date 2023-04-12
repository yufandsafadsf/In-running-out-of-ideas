using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerScript : MonoBehaviour
{



    public Slider slideHunger;
    public Image fill;


    public void SetMaxHunger(int Hunger)
    {
        slideHunger.maxValue = Hunger;
        slideHunger.value = Hunger;
    }

    public void setHunger(int Hunger)
    {
        slideHunger.value = Hunger;

    }

}