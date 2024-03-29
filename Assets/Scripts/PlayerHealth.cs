﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] int health = 10;
	[SerializeField] int healthDecrease = 1;
	[SerializeField] Text healthText;
	[SerializeField] AudioClip blowUpSFX;

	private void Start() {
		if(healthText != null) {
			healthText.text = health.ToString();
		}
		
	}

	private void OnTriggerEnter(Collider other) {
		health -= healthDecrease;
		healthText.text = health.ToString();
		GetComponent<AudioSource>().PlayOneShot(blowUpSFX);
	}
}
