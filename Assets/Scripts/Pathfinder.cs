using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;

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
			var searchCenter = queue.Dequeue();
			print("Searching from: " + searchCenter); //todo remove log
			HaltIfEndFound(searchCenter);
			ExploreNeighbors(searchCenter);
			searchCenter.isExplored = true;
		}

		//todo work out path
		print("Finished pathfinding?");
	}

	private void HaltIfEndFound(Waypoint searchCenter) {
		if(searchCenter == endWaypoint) {
			print("Found End Node, Therefor Stopping"); //todo remove log
			isRunning = false;
		}
	}

	private void ExploreNeighbors(Waypoint from) {
		if (!isRunning) { return; }
		foreach(Vector2Int direction in directions) {
			Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
			try {
				QueueNewNeighbors(neighbourCoordinates);
			} catch {
				//Do Nothing
			}
			
		}
	}

	private void QueueNewNeighbors(Vector2Int neighbourCoordinates) {
		Waypoint neighbour = grid[neighbourCoordinates];
		if(!neighbour.isExplored) {
			neighbour.SetTopColor(Color.blue); //todo move later
			queue.Enqueue(neighbour);
			print("Quueing " + neighbour);
		} else {
			neighbour.SetTopColor(Color.yellow);
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
