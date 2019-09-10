using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] float movementPeriod = 0.5f;
	[SerializeField] ParticleSystem goalParticle;

	// Start is called before the first frame update
	void Start() {
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		var path = pathfinder.GetPath();
		StartCoroutine(FollowPath(path));
	}

	IEnumerator FollowPath(List<Waypoint> path) {

		foreach(Waypoint waypoint in path) {
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(movementPeriod);
		}
		SelfDestruct(); 
	}


	void SelfDestruct() {
		var selfDestructFX = Instantiate(goalParticle, transform.position, Quaternion.identity);
		selfDestructFX.Play();
		 
		Destroy(selfDestructFX.gameObject, selfDestructFX.main.duration);
		Destroy(gameObject);
	}

}
