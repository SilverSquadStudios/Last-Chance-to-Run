using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public PlayerControl Player;
	private Vector3 PlayerPosition;
	private float Distance;

	void Start () 
	{
		Player = FindObjectOfType<PlayerControl> ();
		PlayerPosition = Player.transform.position;
	}
	

	void Update ()
	{
		Distance = Player.transform.position.x - PlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + Distance, transform.position.y, transform.position.z);
		PlayerPosition = Player.transform.position;
	}
}
