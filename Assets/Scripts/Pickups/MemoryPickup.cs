using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPickup : MonoBehaviour
{
    public string message;
    private MemoryScript memory;
    // Start is called before the first frame update
    void Start()
    {
        memory = FindObjectOfType<MemoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            memory.setDisplaying(true);
            memory.setMessage(message);
            Destroy(gameObject);
        }
    }


}
