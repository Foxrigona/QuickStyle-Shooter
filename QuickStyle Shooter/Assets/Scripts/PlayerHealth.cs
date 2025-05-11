using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] float colorChangerLength = 0.3f;
    private SpriteRenderer r;
    private HealthDisplayer healthDisplayer;

    new public void Start()
    {
        base.Start();
        healthDisplayer = FindObjectOfType<HealthDisplayer>();
        healthDisplayer.changeHealth(this.maxHealth, this.currentHealth);
        r = GetComponent<SpriteRenderer>();
    }

    new public void decreaseHealth(int damageDealt)
    {
        this.currentHealth = Mathf.Clamp(currentHealth - damageDealt, 0, this.maxHealth);
        healthDisplayer.changeHealth(this.maxHealth, this.currentHealth);
        StartCoroutine(DamageShower());
        if(currentHealth == 0)
            SceneTransition.Lose();
    }

    public IEnumerator DamageShower()
    {
        r = GetComponent<SpriteRenderer>();
        Debug.Log(Color.white);
        r.color = Color.red;
        yield return new WaitForSeconds(colorChangerLength);
        r.color = Color.white;
    }
}
