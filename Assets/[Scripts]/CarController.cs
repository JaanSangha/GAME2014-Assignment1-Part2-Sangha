/*
CarController.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the car enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float verticalSpeed;
    public float verticalBoundary;

    //ref to player class
    public PlayerController playerref;

    private int randNum;
    private Vector3 laneOne;
    private Vector3 laneTwo;
    private Vector3 laneThree;

    private void Start()
    {
        //set lane cords
        laneOne = new Vector3(12f, -1.3f, 0);
        laneTwo = new Vector3(12f, -2.75f, 0);
        laneThree = new Vector3(12f, -4.2f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    //reset background to starting scrolling position
    private void _Reset()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        //make x value random
        laneOne = new Vector3(Random.Range(12, 16), -1.5f, 0);
        laneTwo = new Vector3(Random.Range(12, 16), -2.84f, 0);
        laneThree = new Vector3(Random.Range(12, 16), -4.44f, 0);

        //decide which lane to spawn
        int rand = Random.Range(1, 15);
        if (rand <=5)
        {
            transform.position = laneOne;
        }
        if (rand >6 && rand <=10)
        {
            transform.position = laneTwo;
        }
        if (rand >10)
        {
            transform.position = laneThree;
        }
    }
    //move thru the screen
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }
    //check if  past the screen
    private void _CheckBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
            playerref.AddScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reset if collides with player
        if (collision.tag == "Player")
        {
            _Reset();
        }
    }

}
