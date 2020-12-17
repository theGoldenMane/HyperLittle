using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimController : MonoBehaviour
{

	public float speed = 10.0f;
	PlayerController target;
	private Vector2 moveDirection;

    void Update()
    {
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        moveDirection.Normalize();
        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
