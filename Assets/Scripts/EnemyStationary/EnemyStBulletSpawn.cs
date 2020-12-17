using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStBulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource audioSrc;

    private float timer;
    public float fireCooldown = 1;
    private float soundTimer;
    public float soundCooldown = 1;
    public float angleMovement = 10f;

    void Update()
    {
        timer += Time.deltaTime;
        soundTimer += Time.deltaTime;
        if (timer > fireCooldown) {
            Instantiate(bullet, transform.position, transform.rotation);
            float rotation = gameObject.transform.localEulerAngles.z - angleMovement;
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z + rotation);
            timer = 0;
            if (soundTimer > soundCooldown) {
                audioSrc.Play();
                soundTimer = 0;
            }
        }
    }
}
