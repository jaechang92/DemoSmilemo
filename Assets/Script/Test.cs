using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public float moveSpeed = 5f; // speed at which the object moves
    public float moveDistance = 2f; // distance the object moves in either direction
    private bool moveRight = true; // whether the object is currently moving right

    private void Update()
    {
        TestMove();
    }

    //좌우 이동
    private void TestMove()
    {
        // move the object
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        // check if the object has moved its distance and change direction
        if (Mathf.Abs(transform.position.x) >= moveDistance)
        {
            moveRight = !moveRight;
        }
    }
}
