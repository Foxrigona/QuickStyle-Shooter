using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : Health
{
    private static int enemiesKilled = 0;
    protected override void kill()
    {
        Instantiate(deathSound);
        enemiesKilled += 1;
        Destroy(this.gameObject);
    }

    public static void resetKillCount()
    {
        enemiesKilled = 0;
    }

    public static int getKillCount()
    {
        return enemiesKilled;
    }
}
