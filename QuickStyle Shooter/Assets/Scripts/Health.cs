using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;
    [SerializeField] private GameObject deathSound;
    

    public void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    public void decreaseHealth(int damageDealt)
    {
        this.currentHealth = Mathf.Clamp(currentHealth - damageDealt,0,this.maxHealth);
        if (this.currentHealth <= 0) kill();
    }

    protected void kill()
    {
        Instantiate(deathSound);
        Destroy(this.gameObject);
    }
}
