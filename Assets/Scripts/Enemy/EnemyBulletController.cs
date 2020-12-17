using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
	public float speed = 10.0f;
	private Rigidbody2D rigidBody;
    public float bulletDamage = 0.25f;
    public static float damage;

	PlayerController target;
	private Vector2 moveDirection;

    GameObject enemy;

	void Start()
    {
        damage = bulletDamage;
        rigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y+3);

        moveDirection.Normalize();
        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        Destroy(gameObject, 3f);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.name.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
