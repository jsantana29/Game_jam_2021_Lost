using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHp = 5;
    private int hp = 0;

    void Start()
    {
        hp = maxHp;   
    }

    public void Damage(int dmg) 
    {
        hp -= dmg;

        if (hp <= 0) 
        {
            Deactivate();
        }
    }

    private void Deactivate() 
    {
        gameObject.SetActive(false);
    }
}
