﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public PlayerProgress playerProgress;

    public float health = 100;

    public void dealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
