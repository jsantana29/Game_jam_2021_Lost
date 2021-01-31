using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryScript : MonoBehaviour
{
    private string message;
    private bool isDisplaying;
    

    private float currentTimer;
    private const float MAX_TIMER = 5F;
    // Start is called before the first frame update
    void Start()
    {
        message = "";
        isDisplaying = false;
        currentTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = message;
        if (isDisplaying)
        {
            currentTimer += Time.deltaTime;

            if(currentTimer >= MAX_TIMER)
            {
                isDisplaying = false;
                currentTimer = 0;
            }
        }

        if (!isDisplaying)
        {
            message = "";
        }
    }

    public void setDisplaying(bool display)
    {
        isDisplaying = display;
    }

    public void setMessage(string message)
    {
        this.message = message;
    }
}
