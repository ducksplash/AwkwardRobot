using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

	public GameObject dialogBoxPanel;
	public GameObject levelEndStats;
	public GameObject PausedPane;
	public GameObject QuitPane;
	public GameObject QuitButton;
	public GameObject PauseButton;
	public Text titleText;
	public Text timeText;
	public Text scoreText;
	public Text scoreTextTotal;
	public int tempLevel = 1;

	private Boolean levelOver = false;

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!levelOver)
		{

			// Process end of level
			if (other.name.Contains("Player"))
			{

				CountUpTimer.clockStopped = true;

				dialogBoxPanel.GetComponent<CanvasGroup>().alpha = 1.0f;
				dialogBoxPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

				levelEndStats.GetComponent<CanvasGroup>().alpha = 1.0f;
				levelEndStats.GetComponent<CanvasGroup>().blocksRaycasts = true;

				PausedPane.GetComponent<CanvasGroup>().alpha = 0.0f;
				PausedPane.GetComponent<CanvasGroup>().blocksRaycasts = false;

				QuitPane.GetComponent<CanvasGroup>().alpha = 0.0f;
				QuitPane.GetComponent<CanvasGroup>().blocksRaycasts = false;

				PauseButton.GetComponent<CanvasGroup>().alpha = 0.0f;
				PauseButton.GetComponent<CanvasGroup>().blocksRaycasts = false;

				QuitButton.GetComponent<CanvasGroup>().alpha = 0.0f;
				QuitButton.GetComponent<CanvasGroup>().blocksRaycasts = false;


				titleText.text = "Level " + PlayerStats.CURRENT_LEVEL + " Complete!";

				timeText.text = CountUpTimer.finalTime.ToString();


				// potential score for level is the level number times 100
				var potentialScore = PlayerStats.CURRENT_LEVEL * 100;

				var countFinalTime = Convert.ToInt32(CountUpTimer.finalTime);

				var scoreMaffs = 0;

				if (countFinalTime < 101)
				{
					scoreMaffs = potentialScore - countFinalTime;
				}
				else
				{
					scoreMaffs = 0;
				}



				PlayerStats.PLAYER_SCORE += scoreMaffs;



				scoreText.text = scoreMaffs.ToString();


				scoreTextTotal.text = (PlayerStats.PLAYER_SCORE).ToString();

				// stop play here

				levelOver = true;
				Time.timeScale = 0;

			}

		}

	}


	
	
	
	
	
	
	
	
	
	
}
