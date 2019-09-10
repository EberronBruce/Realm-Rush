using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] Text spawnEnemies;
	[SerializeField] AudioClip spawnEnemySFX;

	int score = 0;

	// Start is called before the first frame update
	void Start() {
		StartCoroutine(SpawnEnemy());
		spawnEnemies.text = score.ToString();
	}

	IEnumerator SpawnEnemy() {
		
		while(true) {   // forever
			GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
			Instantiate(enemyPrefab, transform.position, Quaternion.identity, gameObject.transform);
			AddScore();
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}

	}

	private void AddScore() {
		score++;
		spawnEnemies.text = score.ToString();
	}
}
