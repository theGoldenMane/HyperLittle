using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
	public static GlobalGameManager Instance;

	public float playerHealth = 1.0f;
	public bool enemy1Alive = true;
	public bool enemy2Alive = true;
	public bool enemy3Alive = true;
	public string previousScene = null;
	public bool reset = false;
	public bool doorHighlightReset = false;
	public bool doorTopStayOpen = false;
	public bool doorRightStayOpen = false;
	public bool doorLeftStayOpen = false;
	public bool startBlinking = false;
	public bool playerTakeDamage = true;
	public bool controllerConnected = false;

	void Awake ()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	void Update() {
		if (reset) {
			playerHealth = 1.0f;
			enemy1Alive = true;
			enemy2Alive = true;
			enemy3Alive = true;
			previousScene = null;
			doorHighlightReset = true;
			reset = false;
		}
		if (SceneManager.GetActiveScene().name == "R1" & enemy1Alive == false) {
			GameObject enemy = GameObject.Find("Enemy");
			if (enemy != null) {
				Destroy(enemy);
			}
		} else if (SceneManager.GetActiveScene().name == "R2" & enemy2Alive == false) {
			GameObject enemy = GameObject.Find("Enemy");
			if (enemy != null) {
				Destroy(enemy);
			}
		} else if (SceneManager.GetActiveScene().name == "R3" & enemy3Alive == false) {
			GameObject enemy = GameObject.Find("Enemy");
			if (enemy != null) {
				Destroy(enemy);
			}
		}

		string[] controller = Input.GetJoystickNames();
		if (Input.GetJoystickNames().Length == 0) {
			controllerConnected = false;
		} else {
			if (controller[0] != "") {
				controllerConnected = true;
			} else {
				controllerConnected = false;
			}
		}

	}
}
