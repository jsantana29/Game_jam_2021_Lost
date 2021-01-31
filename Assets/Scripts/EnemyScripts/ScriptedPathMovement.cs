using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedPathMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float minDist = 0.2f;
    [SerializeField] List<Transform> nodes;
    private int currentNode = 0;
    private bool moving = true;

    void Start()
    {
        currentNode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move();

            if (Vector2.Distance(transform.position, nodes[currentNode].position) < minDist)
            {
                UpdateNode();
            }
        }
    }

    public void StartMoving() 
    {
        moving = true;
    }

    public void StopMoving() 
    {
        moving = false;
    }

    private void Move()
    {
        float dist = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, nodes[currentNode].position, dist);
    }

    private void UpdateNode() 
    {
        currentNode++;

        if (currentNode >= nodes.Count) 
        {
            currentNode = 0;
        }
    }
}
