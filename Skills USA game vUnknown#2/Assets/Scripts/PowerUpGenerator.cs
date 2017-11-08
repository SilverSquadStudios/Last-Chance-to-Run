using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpGenerator : MonoBehaviour
{
	public ObjectPooler SlowDownPool;
	public float SlowDownPowerUpTime;
	public float SlowDownPowerUpTimeCurrent;
	public Text SlowDownText;

	public PlayerControl ThePlayer;

	void Start()
	{
		SlowDownPowerUpTimeCurrent = 0;
	}

	public void SpawnSlowDown( Vector2 position)
	{
		GameObject SlowDown = SlowDownPool.GetPooledObject ();
		SlowDown.transform.position = position;
		SlowDown.SetActive (true);
	}

	public void SlowDownPowerUp()
		{
		 SlowDownPowerUpTimeCurrent = SlowDownPowerUpTime;
		}
	void Update()
	{
		if (SlowDownPowerUpTimeCurrent > 0)
		{
			ThePlayer.SlowDownPowerUp = true;
			SlowDownPowerUpTimeCurrent += -Time.deltaTime;
			SlowDownText.text = "Power Up: " + Mathf.Round (SlowDownPowerUpTimeCurrent);
			SlowDownText.gameObject.SetActive (true);
		} 
		else
		{
			ThePlayer.SlowDownPowerUp = false;
			SlowDownText.gameObject.SetActive (false);
		}


	}

}
