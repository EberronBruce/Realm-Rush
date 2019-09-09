using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem hitPartclePrefab;
	[SerializeField] ParticleSystem deathParticlePrefab;

	// Start is called before the first frame update
	void Start() {

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
	}

	private void KillEnemy() {
		var deathFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
		deathFX.Play();
		Destroy(gameObject);
	}

}
