using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] private int contactDmg = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) 
        {
            Debug.Log("Doing " + contactDmg + " contact dmg");
            //DO DMG TO PLAYER
        }
    }
}
