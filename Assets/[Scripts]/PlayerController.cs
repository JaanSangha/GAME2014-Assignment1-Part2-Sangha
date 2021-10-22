/*
PlayerController.cs
Jaan Sangha - 101264598
Last Modified: Oct 21, 2021
Description: this script controls the movement and behaviour of the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    private Vector3 laneOne;
    private Vector3 laneTwo;
    private Vector3 laneThree;

    public int currentLane;
    public int Lives;
    public int Score;
    public GameObject projectilePrefab;
    public PauseButtonManager menuref;

    AudioSource hit;

    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;
    public Text Scoretext;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        hit = GetComponent<AudioSource>();

        Lives = 3;
        Score = 0;

        laneOne = new Vector3(-8f, -1.3f, 0);
        laneTwo = new Vector3(-8f, -2.75f, 0);
        laneThree = new Vector3(-8f, -4.2f, 0);

        Scoretext.text= ("SCORE: " + Score);

        transform.position = new Vector3(-8f, -2.75f, 0);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("touch");
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _Move();
                Debug.Log("touch");
            }
        }
        UIUpdate();

        if(Lives <1)
        {
            menuref.OngameOver();
        }
        if (Score >2400)
        {
            menuref.OnGameWon();
        }
    }

    private void _Move()
    {
        Vector2 tapSpot;

        tapSpot = Input.GetTouch(0).position;

        if (tapSpot.y > Screen.height / 2 && tapSpot.x < Screen.width / 2)
        {
            if (transform.position.y == laneThree.y)
            {
                transform.position = laneTwo;
            }
            else if (transform.position.y == laneTwo.y)
            {
                transform.position = laneOne;
            }
        }
        else if (tapSpot.y <= Screen.height / 2 && tapSpot.x < Screen.width / 2)
        {
            if (transform.position.y == laneTwo.y)
            {
                transform.position = laneThree;
            }
            else if (transform.position.y == laneOne.y)
            {
                transform.position = laneTwo;
            }
        }

        if (tapSpot.x > Screen.width / 2)
        {
            Fire();
        }

    }

    public float GetYPos()
    {
        return transform.position.y;
    }

    public void AddHealth()
    {
        if (Lives < 3)
        {
            Lives++;
        }
    }

    public void AddScore()
    {
        Score = Score+ 100;
        Scoretext.text = ("SCORE: " + Score);
    }

    void UIUpdate()
    {
        if(Lives ==3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true);
        }
        else if (Lives ==2)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(false);
        }
        else if (Lives == 1)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(false);
            heartThree.SetActive(false);
        }
        else if (Lives == 0)
        {
            heartOne.SetActive(false);
            heartTwo.SetActive(false);
            heartThree.SetActive(false);
        }
    }
    public void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car" || collision.tag == "Dagger" || collision.tag == "Bomb" || collision.tag == "Ninja")
        {
            hit.Play();
            Lives--;
        }
    }

}
