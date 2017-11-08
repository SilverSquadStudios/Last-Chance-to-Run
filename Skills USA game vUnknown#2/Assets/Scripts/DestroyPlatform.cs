using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour {

	public GameObject Point;

	void Start ()
	{
		Point = GameObject.Find ("PlatformDestroyPoint");
	}
	

	void Update () 
	{
		if (transform.position.x < Point.transform.position.x) 
		{
			gameObject.SetActive(false);
		}
	}
}
