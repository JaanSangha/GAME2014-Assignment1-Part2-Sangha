/*
BombBehaviour.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the planes bomb
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{

    public PlaneController planeref;

    public float horizontalSpeed;
    public float horizontalBoundary;
    public float verticalSpeed;

    private int randNum;
    private float laneOne;
    private float laneTwo;
    private float laneThree;

    bool isGrounded;
    float destinationLane;

    private void Start()
    {
        laneOne = -1.4f;
        laneTwo = -2.9f;
        laneThree = -4.2f;
        LaneChooser();
    }
    void Update()
    {
        if (transform.position.y <= destinationLane)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        if (isGrounded)
        {
            transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
        }
    }

    void LaneChooser()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        int rand = Random.Range(1, 15);
        if (rand <= 5)
        {
            destinationLane = laneOne;
        }
        if (rand > 5 && rand <=10)
        {
            destinationLane = laneTwo;
        }
        if (rand >10 )
        {
            destinationLane = laneThree;
        }
    }

    private void _Reset()
    {
        transform.position = planeref.transform.position;
        planeref.PlaySound();
    }

    private void _CheckBounds()
    {

        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
