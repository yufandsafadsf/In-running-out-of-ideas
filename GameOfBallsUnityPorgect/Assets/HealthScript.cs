using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript {

    private int health;
    private int healthMax;


    public HealthScript(int healthMax) {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int getHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float) health / healthMax;
    }

    public void Damage (int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
    }

    public void heal (int healAmount)
    {
        health += healAmount;

        if (health > healthMax) health = healthMax;
    }
}

