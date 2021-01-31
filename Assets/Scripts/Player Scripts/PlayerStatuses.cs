using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatuses : MonoBehaviour
{
    private bool isInvinsible;
    [SerializeField] private bool redKey;
    [SerializeField] private bool blueKey;
    [SerializeField] private bool greenKey;
    // Start is called before the first frame update
    void Start()
    {
        isInvinsible = false;
        redKey = false;
        blueKey = false;
        greenKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getRed()
    {
        return redKey;
    }

    public bool getBlue()
    {
        return blueKey;
    }

    public bool getGreen()
    {
        return greenKey;
    }

    public void setRed(bool key)
    {
        redKey = key;
    }

    public void setBlue(bool key)
    {
        blueKey = key;
    }

    public void setGreen(bool key)
    {
        greenKey = key;
    }
}
