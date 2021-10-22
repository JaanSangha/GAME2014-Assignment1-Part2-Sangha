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
    //ref to plane class
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
        //set lane y values
        laneOne = -1.4f;
        laneTwo = -2.9f;
        laneThree = -4.2f;
        LaneChooser();
    }
    void Update()
    {
        //check if on floor
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
        //move down and then left when on floor
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

        //choose which lane randomly
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
        //reset to plane position
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
