using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter;

	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Start is called before the first frame update
	void Start() {
		LoadBlocks();
		ColorStartAndEnd();
		Pathfind();
		//ExploreNeighbors();
	}

	private void Pathfind() {
		queue.Enqueue(startWaypoint);

		while(queue.Count > 0 && isRunning) {
			searchCenter = queue.Dequeue();
			HaltIfEndFound();
			ExploreNeighbors();
			searchCenter.isExplored = true;
		}

		//todo work out path
		print("Finished pathfinding?");
	}

	private void HaltIfEndFound() {
		if(searchCenter == endWaypoint) {
			isRunning = false;
		}
	}

	private void ExploreNeighbors() {
		if (!isRunning) { return; }
		foreach(Vector2Int direction in directions) {
			Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
			try {
				QueueNewNeighbors(neighbourCoordinates);
			} catch {
				//Do Nothing
			}
			
		}
	}

	private void QueueNewNeighbors(Vector2Int neighbourCoordinates) {
		Waypoint neighbour = grid[neighbourCoordinates];
		if(!neighbour.isExplored && !queue.Contains(neighbour)) {
			queue.Enqueue(neighbour);
			neighbour.exploredFrom = searchCenter;
		} 
	}

	private void ColorStartAndEnd() {
		startWaypoint.SetTopColor(Color.green);
		endWaypoint.SetTopColor(Color.red);
	}

	private void LoadBlocks() {

		var waypoints = FindObjectsOfType<Waypoint>();

		foreach(Waypoint waypoint in waypoints) {
			var gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos)) {
				Debug.LogWarning("Skipping Overlapping block " + waypoint);
			} else {
				grid.Add(waypoint.GetGridPos(), waypoint);
			}
		}

	}


}
