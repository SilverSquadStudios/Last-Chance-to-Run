using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

	public Health Life;


	void Start () 
	{
		Life = FindObjectOfType<Health> ();
	}


	void OnTriggerEnter2D (Collider2D Player)
	{

		Life.HealthPickUp ();
		gameObject.SetActive (false);


	}
}
