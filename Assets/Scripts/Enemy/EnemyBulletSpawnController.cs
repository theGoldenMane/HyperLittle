using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnController : MonoBehaviour
{
	public GameObject bullet;
    public AudioSource audioSrc;
	public float fireCooldown = 1;
	private float timer;

    void Update()
    {
        timer += Time.deltaTime;
     	if(timer > fireCooldown){ 
     		Instantiate(bullet, transform.position, transform.rotation);
        	timer = 0;
            audioSrc.Play();
     	}
    }
}
