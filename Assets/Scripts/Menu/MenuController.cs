using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	void Start() 
	{
		Cursor.visible = true;
	}

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu-Web");
    }

	public void ShowCredits() {
    	SceneManager.LoadScene("CreditsScreen");
	}

    public void StartGame() {
        GlobalGameManager.Instance.reset = true;
    	SceneManager.LoadScene("R0");
    }

    public void QuitGame() {
    	Application.Quit();
    }
}
