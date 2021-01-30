using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodging : MonoBehaviour
{
    private float dodgeSpeed;
    private float dodgeTime;
    public float currentTime;

    private bool dodging;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        dodgeSpeed = 400f;
        dodgeTime = 0.2f;
        currentTime = 0;
        dodging = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !dodging)
        {
            Debug.Log("dashed");
            dodging = true;
            //rb.velocity = Vector2.zero;
            //rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * dodgeSpeed, ForceMode2D.Force);

        }
    }

    private void FixedUpdate()
    {
        if (dodging)
        {
            currentTime += Time.deltaTime;

            rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * dodgeSpeed, ForceMode2D.Force);
            //rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * dodgeSpeed, ForceMode2D.Force);
            //rb.velocity = new Vector2(rb.velocity.x + 50f, rb.velocity.y + 50f);
            if (currentTime >= dodgeTime)
            {
                currentTime = 0;
                dodging = false;
            }
        }
    }

    void DashTimerMethod()
    {

    }
}
