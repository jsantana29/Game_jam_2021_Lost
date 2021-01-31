using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text text;
    private HealthManager health;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        health = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = health.getHealth().ToString();
    }
}
