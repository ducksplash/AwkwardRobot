using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public GameObject dialogBoxPanel;
	public GameObject PausedPane;
	public GameObject QuitPane;
	public GameObject LevelEndPane;
	public GameObject RetryPane;
	public GameObject QuitButton;
	public GameObject PauseButton;
	public GameObject RetryButton;
	public Text titleText;
	public Text levelText;
	public Text scoreText;
	public Text retriesText;
	public Text retriesSubText;
	public GameObject DontRetryButton;
	public GameObject RetriesExitButton;
	public GameObject UseRetryButton;
	public GameObject PersevereButton;
	public Text retriesExitButtonText;
	public Text retriesDontRetryText;
	public bool playerDead = false;
	
	
	
	
	void ChangeScreen(GameObject onScreen, GameObject offScreen)
	{
		
		//enable the "On Screen"
		onScreen.GetComponent<CanvasGroup>().alpha = 1.0f;
		onScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;	

		//disable the "Off Screen"
		offScreen.GetComponent<CanvasGroup>().alpha = 0.0f;
		offScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;	
		
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{ 
		if (other.name.Contains("Player") && PlayerReady.PLAYER_IS_READY)
		{
			playerDead = true;
			DoRetry();
		}
	
	}
	
	
	
	
	
	public void DoPauseMenu()
	{   
	
		
		// ChangeScreen(on.off);
		ChangeScreen(dialogBoxPanel,PauseButton);
		ChangeScreen(dialogBoxPanel,QuitPane);
		ChangeScreen(PausedPane,LevelEndPane);
		ChangeScreen(PausedPane,QuitButton);
		
		
		titleText.text = "Game Paused";
		levelText.text = (PlayerStats.CURRENT_LEVEL).ToString();
		scoreText.text = (PlayerStats.PLAYER_SCORE).ToString();

		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
	}
	
	public void DoUnpause()
	{
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}

		ChangeScreen(QuitButton,dialogBoxPanel);
		ChangeScreen(PauseButton,PausedPane);
		ChangeScreen(PauseButton,RetryPane);
		
		
	}	
	
		
	
	
	public void DoGameQuit()
	{   
		// ChangeScreen(on.off);
		ChangeScreen(dialogBoxPanel,LevelEndPane);
		ChangeScreen(dialogBoxPanel,PausedPane);
		ChangeScreen(QuitPane,LevelEndPane);
		ChangeScreen(QuitPane,PausedPane);
		ChangeScreen(QuitPane,PauseButton);
		ChangeScreen(QuitPane,QuitButton);
		
		
		
		titleText.text = "Quit Game";

		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
	}	
	
	
	
	
	public void DoRetry()
	{   
	
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}	
	
		// ChangeScreen(on.off);
		ChangeScreen(dialogBoxPanel,LevelEndPane);
		ChangeScreen(RetryPane,LevelEndPane);
		ChangeScreen(RetryPane,QuitPane);
		
		
		
		if (PlayerStats.PLAYER_RETRIES > 0)
		{

			RetryButton.GetComponent<Button>().enabled = true;
			
			
			titleText.text = "Try Again?";
			retriesSubText.text = "You have "+PlayerStats.PLAYER_RETRIES+" retries.";
			retriesText.text = "You'll have "+(PlayerStats.PLAYER_RETRIES - 1).ToString()+" left after this.";
			retriesDontRetryText.text = "Don't Do It";

			
			ChangeScreen(DontRetryButton,RetriesExitButton);
			ChangeScreen(UseRetryButton,PersevereButton);
			

			if (playerDead)
			{
			ChangeScreen(UseRetryButton,DontRetryButton);
			}
		}
		else
		{
			titleText.text = "Game Over";
			retriesSubText.text = "No Retries Left";
			retriesText.text = "Sorry bro!";
			retriesExitButtonText.text = "Quit";
			
			ChangeScreen(RetriesExitButton,DontRetryButton);
			ChangeScreen(PersevereButton,UseRetryButton);
			
			if (playerDead)
			{
				PersevereButton.GetComponent<Button>().enabled = false;
				PersevereButton.GetComponentInChildren<Text>().text = "0 retries left";
			}

			
			
		}


	}
	
	
	
	
}
