using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
  public GameObject bullet;
  public Transform spawnPoint;
  public AudioSource audioSrc;

  private float timer;
  public float fireCooldown = 1;

  void Update() {
    timer += Time.deltaTime;
    if (Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1") > 0) {
      if (timer > fireCooldown) {
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        audioSrc.Play();
        timer = 0;
      }
    }
  }
}
