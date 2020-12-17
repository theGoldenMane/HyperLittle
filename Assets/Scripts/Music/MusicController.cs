using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
	public static MusicController Instance;

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
    	if(SceneManager.GetActiveScene().name == "DeathMenu") {
    		Destroy(gameObject);
    	}
    }
}
