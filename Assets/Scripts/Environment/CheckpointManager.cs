using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private HealthManager health;
    public Transform currentCheckpoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.getHealth() == 0)
        {
            player.transform.position = currentCheckpoint.position;
            health.resetHealth();
        }
    }

    public void setCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }
}
