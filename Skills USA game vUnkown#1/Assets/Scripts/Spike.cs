using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	public Health Life;
	void Start()
	{
		Life = FindObjectOfType<Health> ();
	}

	void OnTriggerEnter2D (Collider2D Player)
	{
		gameObject.SetActive (false);
		Life.SpikeDmg ();
	}
}
