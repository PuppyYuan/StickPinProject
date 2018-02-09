using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    private bool isFly = false;
    private bool isReach = false;
    public float speed = 15;

    private Transform startPoint;
    private Transform circle;
    private Vector3 targetCirclePos;

    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.FindGameObjectWithTag("Circle").transform;
        targetCirclePos = circle.position;
        targetCirclePos.y -= 1.55f;
    }

    void Update()
    {
        if (!isFly)
        {
            if (!isReach)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
                {
                    isReach = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetCirclePos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetCirclePos) < 0.05f)
            {
                transform.position = targetCirclePos;
                transform.parent = circle;
                isFly = false;
            }
        }

    }

    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}
