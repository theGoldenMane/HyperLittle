using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStBulletController : MonoBehaviour
{

	public float speed = 10.0f;
	private Rigidbody2D rigidBody;
    public float bulletDamage = 0.25f;
    public static float damage;
    

	void Start()
    {
        damage = bulletDamage;
    }

    void Update() 
    {
    	transform.position += transform.right * Time.deltaTime *speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.name.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
