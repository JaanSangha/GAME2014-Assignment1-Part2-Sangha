//PauseButtonManager.cs
//Jaan Sangha 101264598

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log(activeScene.name);
       // source = GetComponent<AudioSource>();
    }

    public void OnStartButtonPressed()
    {
      //  source.Play();
        SceneManager.LoadScene("Main");
    }

    public void OnBackButtonPressed()
    {
       // source.Play();
        if ( SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Instructions")
        {
            SceneManager.LoadScene("Start");
        }

        if (SceneManager.GetActiveScene().name == "Controls")
        {
            SceneManager.LoadScene("Instructions");
        }
    }

    public void OnNextButtonPressed()
    {
       // source.Play();
        if (SceneManager.GetActiveScene().name == "Instructions")
        {
            SceneManager.LoadScene("Controls");
        }
        if (SceneManager.GetActiveScene().name == "Controls")
        {
            SceneManager.LoadScene("Start");
        }
    }

    public void OnMenuButtonPressed()
    {
      //  source.Play();
        SceneManager.LoadScene("Start");
    }

    public void OnControlsButtonPressed()
    {
       // source.Play();
        SceneManager.LoadScene("Instructions");
    }

    public void OnExitButtonPressed()
    {
       // source.Play();
        Application.Quit();
    }
}
