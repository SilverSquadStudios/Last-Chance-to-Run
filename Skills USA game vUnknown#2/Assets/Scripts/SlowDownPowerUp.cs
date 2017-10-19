using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPowerUp : MonoBehaviour {

	private PowerUpGenerator ThePowerUpGnerator;


	void Start()
	{
		ThePowerUpGnerator = FindObjectOfType<PowerUpGenerator> ();
	}
	void OnTriggerEnter2D (Collider2D Player)
	{
			gameObject.SetActive (false);
		    ThePowerUpGnerator.SlowDownPowerUp ();
	}


}
