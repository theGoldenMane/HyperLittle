using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActionController : MonoBehaviour
{
    public int id;
	public Animator animator;
    public GameObject doorOpenObject = null;

    void Update()
    {
        switch(id) {
            case 1: if(GlobalGameManager.Instance.doorLeftStayOpen == true) {
                        doorOpenObject.SetActive(true);
                        Destroy(gameObject);
                        deactivateCollider();
                    } else if(GlobalGameManager.Instance.enemy1Alive == false) {
                        animator.SetBool("DoorOpen", true);
                    }
                    break;
            case 2: 
                    if(GlobalGameManager.Instance.doorTopStayOpen == true) {
                        Destroy(gameObject);
                        deactivateCollider();
                    } else if(GlobalGameManager.Instance.enemy2Alive == false) {
                        animator.SetBool("DoorOpen", true);
                    }
                    break;
            case 3: if(GlobalGameManager.Instance.doorRightStayOpen == true) {
                        doorOpenObject.SetActive(true);
                        Destroy(gameObject);
                        deactivateCollider();
                    } else if(GlobalGameManager.Instance.enemy3Alive == false) {
                        animator.SetBool("DoorOpen", true);
                    }
                    break;
        }
    }


    void DoorStayOpen() {
        switch(id) {
            case 1: GlobalGameManager.Instance.doorLeftStayOpen = true;
                    doorOpenObject.SetActive(true);
                    break;
            case 2: GlobalGameManager.Instance.doorTopStayOpen = true;
                    break;
            case 3: GlobalGameManager.Instance.doorRightStayOpen = true;
                    doorOpenObject.SetActive(true);
                    break;
        }
        deactivateCollider();
    }

    void deactivateCollider() {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }
}
