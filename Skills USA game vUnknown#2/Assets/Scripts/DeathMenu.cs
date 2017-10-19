using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public string MainMenuLevel;
	public GameManager TheGameManager;

	public void RestartGame()
	{
		Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMain()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (MainMenuLevel);
	}
}
