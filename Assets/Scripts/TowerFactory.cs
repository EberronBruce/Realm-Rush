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
		baseWaypoint.isPlaceable = false;

		tower.BaseWaypoint = baseWaypoint;

		towersQueue.Enqueue(tower);
	}

	private void MoveExistingTower(Waypoint baseWaypoint) {
	
		var oldTower = towersQueue.Dequeue();
		// Set placable flags
		oldTower.BaseWaypoint.isPlaceable = true;
		////set the baseWaypoints
		//oldTower.BaseWaypoint = baseWaypoint;
		//// put the old tower on to of the queue
		//towersQueue.Enqueue(oldTower);
	}

}
