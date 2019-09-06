﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

	Waypoint waypoint;

	private void Awake() {
		waypoint = GetComponent<Waypoint>();
	}

	void Update() {
		SnapToGrid();
		UpdateLabel();
	}

	private void SnapToGrid() { 
		transform.position = new Vector3(
			waypoint.GetGridPos().x,
			0f,
			waypoint.GetGridPos().y
		);
	}

	private void UpdateLabel() {
		int gridSize = waypoint.GetGridSize();
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
		textMesh.text = labelText;
		gameObject.name = labelText;
	}
}
