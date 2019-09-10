using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

	Queue<Tower> towersQueue = new Queue<Tower>();

	public void AddTower(Waypoint baseWaypoint) {
		var numTowers = towersQueue.Count;
		if (numTowers < towerLimit) {
			InstantiateNewTower(baseWaypoint);
		} else {
			MoveExistingTower(baseWaypoint); 
		}

	}

	private void InstantiateNewTower(Waypoint baseWaypoint) {
		var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);

		tower.BaseWaypoint = baseWaypoint;
		baseWaypoint.isPlaceable = false;

		towersQueue.Enqueue(tower);
	}

	private void MoveExistingTower(Waypoint newBaseWaypoint) {
	
		var oldTower = towersQueue.Dequeue();
		oldTower.BaseWaypoint.isPlaceable = true;
		newBaseWaypoint.isPlaceable = false;

		oldTower.BaseWaypoint = newBaseWaypoint;
		oldTower.transform.position = newBaseWaypoint.transform.position;
		
		towersQueue.Enqueue(oldTower);
	}

}
