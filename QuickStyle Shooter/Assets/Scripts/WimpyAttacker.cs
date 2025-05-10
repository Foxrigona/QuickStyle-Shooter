using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WimpyAttacker : Shooter
{
    [SerializeField] protected float shootingDelay = 1f;
    override
    public void attack()
    {
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
            attack();
            yield return new WaitForSeconds(shootingDelay);
        }
    }
}
