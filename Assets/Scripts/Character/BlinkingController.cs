using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingController : MonoBehaviour
{
	public float spriteBlinkingTimer = 0.0f;
	public float spriteBlinkingMiniDuration = 0.1f;
	public float spriteBlinkingTotalTimer = 0.0f;
	public float spriteBlinkingTotalDuration = 1.0f;
	
	void Update()
	{
		if (GlobalGameManager.Instance.startBlinking == true)
		{
			StartBlinkingEffect();
		}
	}

	private void StartBlinkingEffect()
	{
		spriteBlinkingTotalTimer += Time.deltaTime;
		if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
		{
			GlobalGameManager.Instance.startBlinking = false;
			GlobalGameManager.Instance.playerTakeDamage = true;
			spriteBlinkingTotalTimer = 0.0f;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			return;
		}

		spriteBlinkingTimer += Time.deltaTime;
		if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
		{
			spriteBlinkingTimer = 0.0f;
			if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
	}
}
