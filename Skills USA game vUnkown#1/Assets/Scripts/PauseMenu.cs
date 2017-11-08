using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string MainMenuLevel;
	public GameObject Pausemenu;
	public GameManager TheGameManager;
    public PauseMenu ThePauseMenu;

    public void pauseGame()
    {
        ThePauseMenu.Pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

	public void UnpauseGame()
	{
		Time.timeScale = 1f;
		Pausemenu.SetActive (false);
	}


	public void QuitToMain()
	{
		//Time.timeScale = 1f;
		//Pausemenu.SetActive (false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

	public void RestartGame()
	{
		Time.timeScale = 1f;
		Pausemenu.SetActive (false);
		FindObjectOfType<GameManager> ().Reset();

	}
}
