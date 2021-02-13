using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    private const int MAX_HEALTH = 30;
    private bool iFrames;
    private float currentTimer;
    private const float MAX_IFRAMES = 1f;
    // Start is called before the first frame update
    void Start()
    {
        iFrames = false;
        currentHealth = MAX_HEALTH;
        Debug.Log("Helllooooooooooo!");
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames)
        {
            currentTimer += Time.deltaTime;

            if(currentTimer >= MAX_IFRAMES)
            {
                currentTimer = 0;
                iFrames = false;
            }
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void damagePlayer(int damage)
    {
        if (!iFrames)
        {
            currentHealth -= damage;
            iFrames = true;
        }
        
    }

    public void resetHealth()
    {
        currentHealth = MAX_HEALTH;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void healPlayer(int health)
    {
        currentHealth += health;
    }
}
