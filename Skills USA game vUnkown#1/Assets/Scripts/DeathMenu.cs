using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

	public string MainMenuLevel;
	public GameManager TheGameManager;
    public int num;
    public int guessNum;
    public int hi;

    [SerializeField]
    public Text text;

    [SerializeField]
    private InputField input;

    private void Awake()
    {
        hi = Random.Range(1, 5);
    }

    void compareanswer(int guess)
    {
            RestartGame();
    }

    public void text_changed(string guess)
    {
        
        compareanswer(int.Parse(guess));
        input.text = "";
        
    }

	public void RestartGame()
	{
        Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset ();
	}

    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
