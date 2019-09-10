using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem hitPartclePrefab;
	[SerializeField] ParticleSystem deathParticlePrefab;

	private void OnParticleCollision(GameObject other) {
		ProcessHit();
		if(hitPoints < 1) {
			KillEnemy();
		}
	}

	void ProcessHit() {
		hitPoints = hitPoints - 1;
		hitPartclePrefab.Play();
	}

	private void KillEnemy() {
		var deathFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
		deathFX.Play();

		Destroy(deathFX.gameObject, deathFX.main.duration);
		Destroy(gameObject);
	}

}
