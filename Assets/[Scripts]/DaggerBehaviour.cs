/*
DaggerBehaviour.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the dagger
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerBehaviour : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

   //ref to ninja
    public NinjaController ninref;

    void Update()
    {
        _Move();
        _CheckBounds();
    }
    //reset to ninja position
    private void _Reset()
    {
        transform.position = ninref.transform.position;
    }
    //move left
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }
    //check if dagger is past the screen
    private void _CheckBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reset if destroyed
        if (collision.tag == "PlayerProjectile")
        {
            _Reset();
        }
    }
}
