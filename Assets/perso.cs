using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class perso : MonoBehaviour
{
    public float MaxHealth = 10f;
    float currentHealth;

    void Start()
    {
        currentHealth = MaxHealth;

    }
    public void TakeDamage(float aboba)
    {
        currentHealth -= aboba;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}