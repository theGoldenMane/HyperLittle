using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStController : MonoBehaviour
{
    [Header("Settings:")]
    public int id;
    public float healItemSpawnChance = 0.3f;
    public float damageTaken = 0.22f;

    [Space]
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public GameObject healthBar;
    public GameObject healthDrop;

    private float health = 1.0f;


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("PlayerBullet"))
        {
            ReduceHealth(damageTaken);
            if (health <= 0) {
                GlobalGameManager.Instance.enemy2Alive = false;
                gameObject.SetActive(false);
                if(Random.value <= healItemSpawnChance) DropHealthItem();
            }
        } 
    }

    void ReduceHealth(float damage) 
    {
        healthBar.transform.localScale = new Vector3(health - damage, 1.0f);
        health -= damage;
    }

    void DropHealthItem()
    {
  		Instantiate(healthDrop, gameObject.transform.position, transform.rotation);
    }
}