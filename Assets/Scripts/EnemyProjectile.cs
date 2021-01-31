using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyProjectile : MonoBehaviour
{
    [SerializeField] protected Vector2 initialDir;
    [SerializeField] protected Vector2 speed;
    [SerializeField] protected int contactDmg;

    public void SetDirection(Vector2 dir)
    {
        initialDir = dir;
    }

    protected void DestroySelf() 
    {
        Destroy(this);
    }
}
