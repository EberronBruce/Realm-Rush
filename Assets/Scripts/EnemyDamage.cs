using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem hitPartclePrefab;
	[SerializeField] ParticleSystem deathParticlePrefab;
	[SerializeField] AudioClip hitSFX;
	[SerializeField] AudioClip deathSFX;

	AudioSource audioSource;

	private void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	private void OnParticleCollision(GameObject other) {
		ProcessHit();
		if(hitPoints < 1) {
			KillEnemy();
		}
	}

	void ProcessHit() {
		hitPoints = hitPoints - 1;
		hitPartclePrefab.Play();
		audioSource.PlayOneShot(hitSFX);
	}

	private void KillEnemy() {
		var deathFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
		deathFX.Play();

		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
		Destroy(deathFX.gameObject, deathFX.main.duration);
		Destroy(gameObject);
	}

}
