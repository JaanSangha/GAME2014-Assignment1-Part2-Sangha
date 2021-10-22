/*
NinjaController.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the ninja enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{

    public float horizontalSpeed;
    public float horizontalBoundary;

    //ref to player
    public PlayerController playerref;
    public GameObject ninjaPrefab;

    private int randNum;

    private Vector3 laneOne;
    private Vector3 laneTwo;
    private Vector3 laneThree;
    // Start is called before the first frame update
    void Start()
    {
        //set lane values
        laneOne = new Vector3(12f, -1.5f, 0);
        laneTwo = new Vector3(12f, -2.84f, 0);
        laneThree = new Vector3(12f, -4.44f, 0);
    }

    void Update()
    {
        _Move();
        _CheckBounds();
    }
    //reset background to starting scrolling position
    private void _Reset()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        //set random x value
        laneOne = new Vector3(Random.Range(12, 16), -1.5f, 0);
        laneTwo = new Vector3(Random.Range(12, 16), -2.84f, 0);
        laneThree = new Vector3(Random.Range(12, 16), -4.44f, 0);

        //decide which lane to spawn
        int rand = Random.Range(1, 15);
        if (rand <= 5)
        {
            transform.position = laneOne;
        }
        if (rand > 6 && rand <= 10)
        {
            transform.position = laneTwo;
        }
        if (rand > 10)
        {
            transform.position = laneThree;
        }
    }

    private void _ResetDeath()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        //set random x value
        laneOne = new Vector3(Random.Range(15, 19), -1.5f, 0);
        laneTwo = new Vector3(Random.Range(15, 19), -2.84f, 0);
        laneThree = new Vector3(Random.Range(15, 19), -4.44f, 0);

        //decide which lane to spawn
        int rand = Random.Range(1, 15);
        if (rand <= 5)
        {
            transform.position = laneOne;
        }
        if (rand > 6 && rand <= 10)
        {
            transform.position = laneTwo;
        }
        if (rand > 10)
        {
            transform.position = laneThree;
        }
    }

    //move to the left
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    //check if ninja is past the screen
    private void _CheckBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }

    //return ninja x position
    public float GetXPos()
    {
        return transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if colliding
        if (collision.tag == "PlayerProjectile")
        {
            _ResetDeath();
            playerref.AddScore();
        }
        if (collision.tag == "Player")
        {
            _ResetDeath();
        }
    }
}
