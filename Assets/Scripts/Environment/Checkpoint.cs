using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager check;
    // Start is called before the first frame update
    void Start()
    {
        check = FindObjectOfType<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            check.setCheckpoint(this.transform);
        }
    }
}
