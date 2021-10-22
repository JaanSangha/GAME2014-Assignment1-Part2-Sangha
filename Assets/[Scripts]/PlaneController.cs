/*
PlaneController.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the plane enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    //player reference
    public PlayerController playerref;

    AudioSource dropBomb;

    private void Start()
    {
        dropBomb = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    public void PlaySound()
    {
        dropBomb.Play();
    }
    //reset plane to starting scrolling position
    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 2.5f);
    }
    //scroll plane to the left
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }
    //check if plane is past the screen
    private void _CheckBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
            playerref.AddScore();
        }
    }
}
