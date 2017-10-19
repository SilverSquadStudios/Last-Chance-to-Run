using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int ScoreToGive;

	private ScoreManager TheScoreManager;


	void Start () 
	{
		TheScoreManager = FindObjectOfType<ScoreManager> ();
	}
	

	void OnTriggerEnter2D (Collider2D Player)
	{
		
			TheScoreManager.AddScore(ScoreToGive);
			gameObject.SetActive (false);
			

	}
}
