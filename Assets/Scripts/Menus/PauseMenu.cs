using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{


    //return to menu
    public void MenuButton() {
        //reset the time scale
        Time.timeScale = 1.0f;
        //load into the menu
        Application.LoadLevel(0);
    }

    //quit the game
    public void QuitButton() {

        Application.Quit();
    }



}
