using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;
	public Text HighScore;

	public float ScoreCount;
	private float HighScoreCount;

	public float PointsPerSecond;

	public bool ScoreIncrease;

	void Start ()
	{
		if (PlayerPrefs.HasKey ("HighScore")) 
		{
			HighScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}
	

	void Update () 
	{
		if (ScoreIncrease)
		{
			ScoreCount += PointsPerSecond * Time.deltaTime;
		}
		if (ScoreCount > HighScoreCount)
		{
			HighScoreCount = ScoreCount;
			PlayerPrefs.SetFloat ("HighScore", HighScoreCount);
		}

		ScoreText.text = "Score: " + Mathf.Round(ScoreCount);
		HighScore.text = "High Score: " + Mathf.Round(HighScoreCount);
	}

	public void AddScore(int PointsToAdd)
	{
		ScoreCount += PointsToAdd;
	}

}
