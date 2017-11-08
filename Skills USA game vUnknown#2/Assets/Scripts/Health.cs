using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour 
    {

	public Image Life1;
	public Image Life2;
	public Image Life3;
	public Image Life4;

	public float Life;

	private bool Hit;
	public LayerMask WallRecognizing;
	public Transform WallCheck;
	public float WallCheckRadius;
	private float TimeHit;

	private GameManager TheGameManager;
	public PlayerControl ThePlayer;




	void Start()
	{
		TimeHit = .5f;
		Life = 3;
		Hit = false;
		TheGameManager = FindObjectOfType<GameManager> ();

	}

	void Update()
	{
		if (Life == 3)
		{
			Life4.gameObject.SetActive (true);
			Life3.gameObject.SetActive (false);
			Life2.gameObject.SetActive (false);
			Life1.gameObject.SetActive (false);
		}
		if (Life == 2)
		{
			Life4.gameObject.SetActive (false);
			Life3.gameObject.SetActive (true);
			Life2.gameObject.SetActive (false);
			Life1.gameObject.SetActive (false);
		}
		if (Life == 1)
		{
			Life4.gameObject.SetActive (false);
			Life3.gameObject.SetActive (false);
			Life2.gameObject.SetActive (true);
			Life1.gameObject.SetActive (false);
		}
		if (Life == 0)
		{
			Life4.gameObject.SetActive (false);
			Life3.gameObject.SetActive (false);
			Life2.gameObject.SetActive (false);
			Life1.gameObject.SetActive (true);
		}

		Hit = Physics2D.OverlapCircle (WallCheck.position, WallCheckRadius, WallRecognizing);
		if (Hit&&TimeHit<0) 
		{
			Life--;
			TimeHit = .5f;
		}

		if (Life == 0) 
		{
			ThePlayer.ResetGame ();

		}
		TimeHit += -Time.deltaTime;
	}
		
	public void SpikeDmg ()
	{
		Life--;
	}
	public void HealthPickUp()
	{
		if (Life < 3)
		{
			Life++;
		}
	}
}
