using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Start is called before the first frame update
	void Start() {
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy() {
		
		while(true) {   // forever
			Instantiate(enemyPrefab, transform.position, Quaternion.identity, gameObject.transform);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
		
	}
}
