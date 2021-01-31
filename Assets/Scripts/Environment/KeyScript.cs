using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public string keyColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(keyColor == "Red")
            {
                collision.gameObject.GetComponent<PlayerStatuses>().setRed(true);
            }
            else if(keyColor == "Blue")
            {
                collision.gameObject.GetComponent<PlayerStatuses>().setBlue(true);
            }
            else if (keyColor == "Green")
            {
                collision.gameObject.GetComponent<PlayerStatuses>().setGreen(true);
            }

            Destroy(gameObject);
        }
    }
}
