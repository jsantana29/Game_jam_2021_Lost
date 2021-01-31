using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public string doorColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            if(collision.gameObject.GetComponent<PlayerStatuses>().getRed() && doorColor == "Red")
            {
                collision.gameObject.GetComponent<PlayerStatuses>().setRed(false);
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<PlayerStatuses>().getBlue() && doorColor == "Blue")
            {
                collision.gameObject.GetComponent<PlayerStatuses>().setBlue(false);
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<PlayerStatuses>().getGreen() && doorColor == "Green")
            {
                collision.gameObject.GetComponent<PlayerStatuses>().setGreen(false);
                Destroy(gameObject);
            }

            //Destroy(gameObject);
        }
    }

    void Open()
    {

    }
}
