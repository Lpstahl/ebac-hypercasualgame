using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyerHelper : MonoBehaviour
{
    public EnemyBase enemy;

    public void KillEnemy()
    {
        enemy.DestroyEnemy();
    }
}
