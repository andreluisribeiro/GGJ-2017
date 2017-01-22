using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structures : MonoBehaviour {
    public double health;
    public double shield;
    public double shieldTax;

    public void setHealth(double health) { this.health = health; }
    public void setShield(double shield) { this.shield = shield; }
    public double getHealth() { return health; }
    public double getShield() { return shield; }

    public int tier = 0;

    public void Hit(float o)
    {
        float dano = (float)o;
        if (shield > dano * shieldTax)
            shield -= dano * shieldTax;
        else
        {
            health -= dano;
            shield = 0;
        }

        if (health < 0) Destroy(this.gameObject);
    }
}
