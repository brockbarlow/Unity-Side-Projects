using UnityEngine;

public class Title_Manager : MonoBehaviour
{
    public Canvas Title;     //canvas elements related to the title.
    public Canvas MainMenu;  //canvas elements related to the main menu.

    public Canvas SinglePlayer; //canvas elements related to single player modes.
    public Canvas MultiPlayer;  //canvas elements related to the multi player modes.
    public Canvas Options;      //canvas elements related to the overall game options.

    public void Start()
    {
        Title.enabled = true;     //title needs to be enabled on start.

        //all other canvas objects need to be disabled on start.
        MainMenu.enabled = false;
        SinglePlayer.enabled = false;
        MultiPlayer.enabled = false;
        Options.enabled = false;
    }

    public void StartGame()
    {
        Title.enabled = false;   //after click, disable title canvas object.
        MainMenu.enabled = true; //after click, enable main menu canvas object.
    }

    public void LoadSinglePlayer()
    {
        MainMenu.enabled = false;
        SinglePlayer.enabled = true;
    }

    public void LoadMultiPlayer()
    {
        MainMenu.enabled = false;
        MultiPlayer.enabled = true;
    }

    public void LoadOptions()
    {
        MainMenu.enabled = false;
        Options.enabled = true;
    }

    public void ReturnToTitle()
    {
        MainMenu.enabled = false;
        Title.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit(); //stops application from running.
    }
}