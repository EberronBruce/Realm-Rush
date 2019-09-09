using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

	public void AddTower(Waypoint baseWaypoint) {
		var numTowers = FindObjectsOfType<Tower>().Length;
		if (numTowers < towerLimit) {
			InstantiateNewTower(baseWaypoint);
		} else {
			MoveExistingTower(); 
		}

	}

	private static void MoveExistingTower() {
		print("No more towers");
		//todo actually move!
	}

	private void InstantiateNewTower(Waypoint baseWaypoint) {
		Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		baseWaypoint.isPlaceable = false;
	}
}
