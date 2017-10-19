using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string MainMenuLevel;
	public GameObject Pausemenu;
	public GameManager TheGameManager;

    

	public void UnpauseGame()
	{
		Time.timeScale = 1f;
		Pausemenu.SetActive (false);
	}


	public void QuitToMain()
	{
		Time.timeScale = 1f;
		Pausemenu.SetActive (false);
		Application.LoadLevel (MainMenuLevel);
	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		Pausemenu.SetActive (false);
		FindObjectOfType<GameManager> ().Reset();

	}
}
