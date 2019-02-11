using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    //GameObject[] PauseMenuObjects;
    private bool creditsActive;
    private bool controlsActive;
    private bool characterCreatorOn;
    public GameObject creditsOverlay;
    public GameObject controlsOverlay;
    public GameObject characterCreation;

    public GameObject LoadingText;


    private void Start()
    {
        creditsActive = false;
        //creditsOverlay = GameObject.Find("CreditsOverlay");
        creditsOverlay.SetActive(false);
        controlsActive = false;
        //controlOverlay = GameObject.Find("ControlOverlay");
        controlsOverlay.SetActive(false);

        characterCreation.SetActive(false);
        LoadingText.SetActive(false);
        characterCreatorOn = false;
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(1); 
    }

    public void PlayLevelWITHLOADING()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void onMainMenuPlay()
    {
        characterCreation.SetActive(true);
        characterCreatorOn = true;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ControlsMenu()
    {
        if (controlsActive == false)
        {
            controlsOverlay.SetActive(true);
            controlsActive = true;
        }
        else
        {
            controlsOverlay.SetActive(false);
            controlsActive = false;
        }
    }

    public void CreditsMenu()
    {
        if (creditsActive == false)
        {
            creditsOverlay.SetActive(true);
            creditsActive = true;
        }
        else
        {
            creditsOverlay.SetActive(false);
            creditsActive = false;
        }
    }

}
