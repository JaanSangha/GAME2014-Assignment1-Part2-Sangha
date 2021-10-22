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

    public PlayerController playerref;
    public GameObject ninjaPrefab;

    private int randNum;

    private Vector3 laneOne;
    private Vector3 laneTwo;
    private Vector3 laneThree;
    // Start is called before the first frame update
    void Start()
    {

        laneOne = new Vector3(12f, -1.5f, 0);
        laneTwo = new Vector3(12f, -2.84f, 0);
        laneThree = new Vector3(12f, -4.44f, 0);
    }

    void Update()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        //transform.position.y = playerref.GetYPos();
        _Move();
        _CheckBounds();
    }
    //reset background to starting scrolling position
    private void _Reset()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        laneOne = new Vector3(Random.Range(12, 16), -1.5f, 0);
        laneTwo = new Vector3(Random.Range(12, 16), -2.84f, 0);
        laneThree = new Vector3(Random.Range(12, 16), -4.44f, 0);

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

        laneOne = new Vector3(Random.Range(15, 19), -1.5f, 0);
        laneTwo = new Vector3(Random.Range(15, 19), -2.84f, 0);
        laneThree = new Vector3(Random.Range(15, 19), -4.44f, 0);

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

    //scroll background to the left
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    //check if background is past the screen
    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }

    public float GetXPos()
    {
        return transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
