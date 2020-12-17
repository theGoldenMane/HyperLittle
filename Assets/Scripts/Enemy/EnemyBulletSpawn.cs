using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
	public GameObject bullet;
    public AudioSource audioSrc;

	private float timer;
 	public float fireCooldown = 1;

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
