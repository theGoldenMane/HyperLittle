using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorController : MonoBehaviour
{
	public int triggerID;

    [Header("References:")]
    public PlayerController player;


    void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.tag == "Player") {
            //Destroy all left healing items and save player health when player leaves a room
            HealthItemController healingItem = GameObject.FindObjectOfType<HealthItemController>();
            Destroy(healingItem);
            GlobalGameManager.Instance.playerHealth = player.GetHealth();

            GlobalGameManager.Instance.previousScene = SceneManager.GetActiveScene().name;
        	if(triggerID == 2 || triggerID == 4 || triggerID == 6) {
        		SceneManager.LoadScene("R0");
        	} else if (triggerID == 0) {
        		SceneManager.LoadScene("WinScreen-Web");
        	} else if (triggerID == 1) {
         		SceneManager.LoadScene("R1");       		
        	} else if (triggerID == 3) {
        		SceneManager.LoadScene("R2");        		
        	} else if (triggerID == 5) {
        		SceneManager.LoadScene("R3");        		
        	}
        } 
     }
}
