using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public AudioSource audioSource;
    public AudioClip clipButton;
    public float volume = 0.5f;


	
	public void ChangeScene(string sceneName)
	{
		//audioSource.PlayOneShot(clipButton, volume);
		
		PlayerStats.PLAYER_SCORE = 0;
		PlayerStats.PLAYER_RETRIES = 3;
		PlayerStats.CURRENT_LEVEL = 1;
		PlayerStats.DEAD = false;
		SceneManager.LoadScene(sceneName);
	}
	public void Exit()
	{
		PlayerStats.PLAYER_SCORE = 0;
		Application.Quit();
	}

}