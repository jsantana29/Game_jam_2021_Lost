using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyProjectile : MonoBehaviour
{
    protected Vector2 initialDir;
    [SerializeField] protected float speed;
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
