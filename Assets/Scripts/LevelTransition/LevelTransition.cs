using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator animator;
    private string nextScene;


    public void FadeToLevel(string scene) 
    {
    	nextScene = scene;
    	animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
    	SceneManager.LoadScene(nextScene);
    }

}
