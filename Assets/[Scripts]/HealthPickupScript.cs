/*
HealthPickupScript.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the health pickup
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    public PlayerController playerref;

    private int randNum;
    private Vector3 laneOne;
    private Vector3 laneTwo;
    private Vector3 laneThree;

    AudioSource healthPickup;

    private void Start()
    {
        healthPickup = GetComponent<AudioSource>();

        //set lane values
        laneOne = new Vector3(12f, -1.44f, 0);
        laneTwo = new Vector3(12f, -2.89f, 0);
        laneThree = new Vector3(12f, -4.37f, 0);
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

        //make x position random
        laneOne = new Vector3(Random.Range(15, 25), -1.44f, 0);
        laneTwo = new Vector3(Random.Range(15, 25), -2.89f, 0);
        laneThree = new Vector3(Random.Range(15, 25), -4.37f, 0);

        //decide which lane to go into randomly
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
    //move with scene
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }
    //check if item is past the screen
    private void _CheckBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collides with player add health
        if (collision.tag == "Player")
        {
            _Reset();
            playerref.AddHealth();
            healthPickup.Play();
        }
    }

}
