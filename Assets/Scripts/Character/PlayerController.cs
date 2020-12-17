using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
Debug.Log("Log");
Debug.LogWarning("Warning");
Debug.LogError("Error");
CameraSize = Screen.height/PPU/2
*/

public class PlayerController : MonoBehaviour
{
	[Header("Settings:")]
	public float baseSpeed = 1.0f;
	private float movementSpeed;
	private Vector2 movementDirection;
	private float health = 1.0f;
	private float maxHealth = 1.0f;
	private bool isMoving;
	private Vector2 mousePos;

	[Space]
	[Header("References:")]
	public Rigidbody2D rigidBody;
	public Animator animator;
	public GameObject healthBar;
	public GameObject PauseMenu;
	public AudioSource audioSrc;
	public GameObject crossHair;
	public Camera cam;

	void Start ()
	{
		health = GlobalGameManager.Instance.playerHealth;
		SetHealth(health);
		isMoving = false;

		if (SceneManager.GetActiveScene().name == "R0") {
			if (GlobalGameManager.Instance.previousScene == "R1") {
				transform.position = new Vector2(27.0f, -1.7f);
			} else if (GlobalGameManager.Instance.previousScene == "R2") {
				transform.position = new Vector2(00.0f, -12.0f);
			} else if (GlobalGameManager.Instance.previousScene == "R3") {
				transform.position = new Vector2(-27.0f, -1.7f);
			}
		}
	}

	void Update()
	{
		//Make Cursor invisible
		Cursor.visible = true;
		if (PauseMenu.activeSelf == false) {
			Cursor.visible = false;
		}

		if(GlobalGameManager.Instance.controllerConnected == false) {
			crossHair.SetActive(true);
			ShowCrossHair();	
		} else {
			crossHair.SetActive(false);
		}

		ProcessInput();
		Move();
		Animate();
		PlaySoundEffects();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("EnemyBullet") && GlobalGameManager.Instance.playerTakeDamage == true)
		{
			if (EnemyBulletController.damage != 0) {
				GlobalGameManager.Instance.startBlinking = true;
				ReduceHealth(EnemyBulletController.damage);
				GlobalGameManager.Instance.playerTakeDamage = false;
			} else {
				GlobalGameManager.Instance.startBlinking = true;
				ReduceHealth(EnemyStBulletController.damage);
				GlobalGameManager.Instance.playerTakeDamage = false;
			}
			if (health <= 0) {
				SceneManager.LoadScene("DeathMenu-Web");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (target.gameObject.tag.Equals("HealthItem"))
		{
			IncreaseHealth(HealthItemController.healPoints);
			Destroy(target.gameObject);
		}
	}

	void ProcessInput() {
		movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
	}

	void Move() {
		rigidBody.velocity = movementDirection * movementSpeed * baseSpeed;
		if (rigidBody.velocity.x != 0 || rigidBody.velocity.y != 0) {
			isMoving = true;
		} else {
			isMoving = false;
		}
	}

	void Animate() {
		animator.SetFloat("Horizontal", movementDirection.x);
		animator.SetFloat("Vertical", movementDirection.y);
	}

	void PlaySoundEffects() {
		if (isMoving && !audioSrc.isPlaying) {
			audioSrc.Play();
		} else if (!isMoving && audioSrc.isPlaying) {
			audioSrc.Stop();
		}
	}


	void ReduceHealth(float damage)
	{
		healthBar.transform.localScale = new Vector3(health - damage, health);
		health -= damage;
	}

	void IncreaseHealth(float healPoints) {
		if (health + healPoints > maxHealth) {
			health = maxHealth;
			healthBar.transform.localScale = new Vector3(health, health);
		} else {
			healthBar.transform.localScale = new Vector3(health + healPoints, health);
			health += healPoints;
		}
	}

	void SetHealth(float health) {
		healthBar.transform.localScale = new Vector3(health, health);
	}

	public float GetHealth() {
		return health;
	}

	void ShowCrossHair() {
		mousePos = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		crossHair.transform.position = new Vector2(mousePos.x, mousePos.y);
	}
}
