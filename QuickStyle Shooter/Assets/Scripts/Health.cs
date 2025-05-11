using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected GameObject deathSound;
    

    public void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    public void decreaseHealth(int damageDealt)
    {
        this.currentHealth = Mathf.Clamp(currentHealth - damageDealt,0,this.maxHealth);
        if (this.currentHealth <= 0) kill();
    }

    protected abstract void kill();
}
