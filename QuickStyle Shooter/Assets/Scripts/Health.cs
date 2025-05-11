using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    public AudioSource death;

    public void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    public void decreaseHealth(int damageDealt)
    {
        this.currentHealth -= damageDealt;
        if (this.currentHealth < 0) kill();
    }

    public void kill()
    {
        death.Play();
        Debug.Log("Dead");
        Destroy(this.gameObject);
    }
}
