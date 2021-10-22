/*
PlayerProjectileBehaviour.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the players projectile
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehaviour : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    AudioSource hitrock;

    void Update()
    {
        hitrock = GetComponent<AudioSource>();
        _Move();
        _CheckBounds();
    }
    //move projectile right
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }
    private void _CheckBounds()
    {
        //destroy object if off screen
        if (transform.position.x >= horizontalBoundary)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if hits enemy object
        if (collision.tag != "Player")
        {
            hitrock.Play();
            Destroy(this.gameObject);
        }
    }
}
