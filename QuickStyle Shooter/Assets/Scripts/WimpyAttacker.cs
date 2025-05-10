using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WimpyAttacker : Shooter
{
    [SerializeField] protected float shootingDelay = 1f;
    public AudioSource shoot;
    public GameObject player;

    override
    public void attack()
    {
        shoot.Play();
        Instantiate(this.bullet, bulletSpawnPosition(), Quaternion.AngleAxis(calculateRotation(), Vector3.forward));
    }

    public void Start()
    {
        base.Start();
        StartCoroutine(keepShooting());
    }
    IEnumerator keepShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingDelay + Random.Range(-shootingDelay, 2));
            attack();
        }
    }
}
