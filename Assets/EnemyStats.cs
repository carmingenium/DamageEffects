using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamagable
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 10000;

    // This script is to handle numbers for damages and health, not necessarily related to demo
    public void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public void Revive()
    {
        if(gameObject.activeSelf == false) gameObject.SetActive(true);
        Heal(10000);
    }
}
