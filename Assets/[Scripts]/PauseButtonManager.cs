//PauseButtonManager.cs
//Jaan Sangha 101264598

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonManager : MonoBehaviour
{

    public GameObject ResumeButton;
    public GameObject ExitButton;
    public GameObject EndButton;
    public GameObject BlurScreen;


    //pause game and show buttons when pressed
    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0;
        ResumeButton.SetActive(true);
        ExitButton.SetActive(true);
        EndButton.SetActive(true);
        BlurScreen.SetActive(true);
    }

    //resume game and hide buttons when pressed
    public void OnResumeButtonPressed()
    {
        ResumeButton.SetActive(false);
        ExitButton.SetActive(false);
        EndButton.SetActive(false);
        BlurScreen.SetActive(false);
        Time.timeScale = 1;
    }

    //Send user back to main menu
    public void OnExitButtonPressed()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            SceneManager.LoadScene("Start");
        }
    }

    //Go to end scene (testing)
    public void OnEndButtonPressed()
    {
        SceneManager.LoadScene("End");
    }


}
