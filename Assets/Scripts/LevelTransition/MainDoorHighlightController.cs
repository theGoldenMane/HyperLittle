using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorHighlightController : MonoBehaviour
{
	public GameObject left1;
	public GameObject left2;
	public GameObject right1;
	public GameObject right2;
	public GameObject middle;
	public GameObject disabledMainDoor;
	public GameObject mainDoor;
	public Animator mainDoorAnimator;

    // Update is called once per frame
    void Update()
    {
    	if(GlobalGameManager.Instance.enemy1Alive == false && GlobalGameManager.Instance.enemy2Alive == false && GlobalGameManager.Instance.enemy3Alive == false) {
			right1.SetActive(false);
    		right2.SetActive(false);
        	middle.SetActive(false);
        	left1.SetActive(false);
    		left2.SetActive(false);
        	disabledMainDoor.SetActive(false);
			mainDoor.SetActive(true);
    	} else {
		if(GlobalGameManager.Instance.enemy1Alive == false) {
    		right1.SetActive(true);
    		right2.SetActive(true);
    	} else {
    		right1.SetActive(false);
    		right2.SetActive(false);
    	}

    	if(GlobalGameManager.Instance.enemy2Alive == false) {
			middle.SetActive(true);
    	} else {
			middle.SetActive(false);
    	}

    	if(GlobalGameManager.Instance.enemy3Alive == false) {
			left1.SetActive(true);
    		left2.SetActive(true);
    	} else {
    		left1.SetActive(false);
    		left2.SetActive(false);
    	}

    	}
    	
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(GlobalGameManager.Instance.enemy1Alive == false && GlobalGameManager.Instance.enemy2Alive == false && GlobalGameManager.Instance.enemy3Alive == false && other.name == "Player") {
           	mainDoorAnimator.SetBool("DoorOpen", true);
        }
    }
}
