using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //

public class MainMenu : MonoBehaviour
{
    //play button
    public void PlayGame()
    {
        //load next scene in queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);     
    }

    //quit button
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //indicator that it worked
        Application.Quit(); //close the program
    }

}
