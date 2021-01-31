using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyImage : MonoBehaviour
{
    public string color;
    public Sprite sprite;

    private PlayerStatuses status;
    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<PlayerStatuses>();
        GetComponent<Image>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(color == "Red")
        {
            if (status.getRed())
            {
                GetComponent<Image>().sprite = sprite;
                makeOpaque();
            }
            else
            {
                GetComponent<Image>().sprite = null;
                makeTransparent();
            }
        }
        else if (color == "Blue")
        {
            if (status.getBlue())
            {
                GetComponent<Image>().sprite = sprite;
                makeOpaque();

            }
            else
            {
                GetComponent<Image>().sprite = null;
                makeTransparent();
            }
        }
        else if (color == "Green")
        {
            if (status.getGreen())
            {
                GetComponent<Image>().sprite = sprite;
                makeOpaque();
            }
            else
            {
                GetComponent<Image>().sprite = null;
                makeTransparent();
            }
        }

    }

    void makeTransparent()
    {
        Color color = GetComponent<Image>().color;
        color.a = 0f;
        GetComponent<Image>().color = color;
    }

    void makeOpaque()
    {
        Color color = GetComponent<Image>().color;
        color.a = 255f;
        GetComponent<Image>().color = color;
    }
}
