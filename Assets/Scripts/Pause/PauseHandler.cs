using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
	public bool isPaused;

	public GameObject PauseMenu;
    public GameObject PauseBackground;

    void Update()
    {
        if(isPaused) {
        	PauseBackground.SetActive(true);
            PauseMenu.SetActive(true);
        	Time.timeScale = 0f;
        } else {
        	PauseBackground.SetActive(false);
            PauseMenu.SetActive(false);
        	Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7")) {
        	isPaused = !isPaused;
        }
    }
}
