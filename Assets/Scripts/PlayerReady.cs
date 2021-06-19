using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerReady : MonoBehaviour
{
	
	public GameObject touchControls;
    
	public static bool PLAYER_IS_READY;
	public GameObject[] theseLights;
	
	
    void Start()
    {
		PLAYER_IS_READY = false;
		theseLights = GameObject.FindGameObjectsWithTag("cubeLights");
    }
	
	
	
	
	
	
	
	public void retryLevel()
	{
		
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		
		PlayerStats.PLAYER_RETRIES--;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		CountUpTimer.clockStopped = false;
	}	
	
	

	public void readyToRun()
	{
		
		
		
		if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            PlayerStats.PLAYER_SELECTEDSPEED = PlayerStats.PLAYER_PCSPEED;
        }

        //Check if the device running this is a handheld
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            PlayerStats.PLAYER_SELECTEDSPEED = PlayerStats.PLAYER_PHONESPEED;
			
			
			touchControls.GetComponent<CanvasGroup>().alpha = 1.0f;
			touchControls.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
		
	
		
		PLAYER_IS_READY = true;

		
		foreach (GameObject thisLight in theseLights)
		{
			thisLight.GetComponent<Light>().color = new Color32(0,0,150,240);
			thisLight.GetComponent<Light>().intensity = 25;
		}		
		
	}


	public void nextLevel()
	{
		
		
		PlayerStats.CURRENT_LEVEL++;		
		
		
		var satisfaction = false;
		for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            var needle = (PlayerStats.CURRENT_LEVEL).ToString();
            if (SceneUtility.GetScenePathByBuildIndex(i).Contains(needle))
			{
	           satisfaction = true;		
				
			}
        }
		
		if (satisfaction)
		{
			var nextLevel = (PlayerStats.CURRENT_LEVEL).ToString();		
			SceneManager.LoadScene(nextLevel);	
		}
		else
		{	
			SceneManager.LoadScene("theend");	
		}
		
		

		

		
		Time.timeScale = 1;
		CountUpTimer.clockStopped = false;
		
	}
		
	
	public void toMainMenu()
    {
		PlayerStats.CURRENT_LEVEL = 0;
		Time.timeScale = 1;						
		PlayerStats.PLAYER_SCORE = 0;
		CountUpTimer.clockStopped = false;
		SceneManager.LoadScene("mainmenu");

    }
	
	public void endGame()
    {
		PlayerStats.PLAYER_SCORE = 0;
		Application.Quit();
    }



	
}
