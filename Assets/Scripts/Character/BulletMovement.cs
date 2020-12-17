using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	public float speed = 10.0f;
	public Animator animator;
	public Rigidbody2D rigidBody;

	void Update() 
    {
    	transform.position += transform.right * Time.deltaTime *speed;
    }

	void OnCollisionEnter2D()
 	{
 		rigidBody.velocity = new Vector2(0, 0);
 		Destroy(gameObject);
 		//animator.SetBool("Burst", true);
 	}
}
