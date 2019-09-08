using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Start is called before the first frame update
	void Start() {
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy() {
		
		while(true) {   // forever
			// spawn enemy
			print("Spawn Enemy");
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
		
	}
}
