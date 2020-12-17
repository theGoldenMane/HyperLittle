using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings:")]
    public int id;
    public float moveSpeed = 5f;
    public float healItemSpawnChance = 0.3f;
    public float damageTaken = 0.22f;
    private Vector2 direction;
    private float distance;

    [Space]
    [Header("References:")]
    public Transform player;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public GameObject healthBar;
    public GameObject healthDrop;

    private float health = 1.0f;

    void Start()
    {
        distance = 10.0f;
    }

    void Update()
    {
        Vector3 movement = player.position - transform.position;
        distance = Vector3.Distance(player.position, transform.position);
        movement.Normalize();
        direction = movement;
    }

    private void FixedUpdate() 
    {
        if(distance > 5) {
            MoveEnemy(direction);
        } else {
            direction.x = 0f;
            direction.y = 0f;
        }
        Animate();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("PlayerBullet"))
        {
            ReduceHealth(damageTaken);
            if (health <= 0) {
                if(id == 1) {
                    GlobalGameManager.Instance.enemy1Alive = false;
                } else if (id == 3) {
                    GlobalGameManager.Instance.enemy3Alive = false;
                }
                gameObject.SetActive(false);
                if(Random.value <= healItemSpawnChance) DropHealthItem();
            }
        } 
    }

    void MoveEnemy(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void Animate() {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
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