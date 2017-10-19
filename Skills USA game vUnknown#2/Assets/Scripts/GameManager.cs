using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform PlatformSpawn;
	private Vector2 PlatformStartPoint;

	public PlayerControl Player;
	private Vector2 PlayerStartPoint;

	private DestroyPlatform[] platformList;

	private ScoreManager TheScoreManager;

	public DeathMenu TheDeathMenu;

	public PauseMenu ThePauseMenu;

	public PlayerControl ThePlayer;

	private PowerUpGenerator ThePowerUpGenerator;

	public Health Health1;

	void Start () 
	{
		PlatformStartPoint = PlatformSpawn.position;
		PlayerStartPoint = Player.transform.position;
		TheScoreManager = FindObjectOfType<ScoreManager> ();
		ThePowerUpGenerator = FindObjectOfType<PowerUpGenerator> ();
	}

	public void RestartGame()
	{
		TheScoreManager.ScoreIncrease = false;
		Player.gameObject.SetActive (false);
		Time.timeScale = 0f;
		TheDeathMenu.gameObject.SetActive (true);
	}

	public void Reset()
	{
		platformList = FindObjectsOfType<DestroyPlatform> ();

		for(int i =0;i<platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}
		Player.transform.position = PlayerStartPoint;
		PlatformSpawn.position = PlatformStartPoint;
		Player.gameObject.SetActive (true);
		TheScoreManager.ScoreCount = 0;
		TheScoreManager.ScoreIncrease = true;
		TheDeathMenu.gameObject.SetActive (false);
		ThePlayer.SlowDownPowerUp = false;
		ThePowerUpGenerator.SlowDownPowerUpTimeCurrent = 0;
		Health1.Life = 3;
		ThePlayer.ResetSpeed ();

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)&&FindObjectOfType<DeathMenu>()==false ) 
		{
			ThePauseMenu.Pausemenu.SetActive (true);
			Time.timeScale = 0f;
		}
	}




}
