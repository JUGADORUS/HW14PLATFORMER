using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human
{
    public void Heal()
    {
        if (currentHealth != maxHealth)
        {
            currentHealth += 50;
        }
    }
}
