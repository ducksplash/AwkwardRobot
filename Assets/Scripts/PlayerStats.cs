using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
	
	
	public static int PLAYER_SCORE = 0;
	public static int PLAYER_RETRIES = 9;
	public static float PLAYER_PCSPEED = 50;
	public static float PLAYER_PHONESPEED = 250;
	public static float PLAYER_SELECTEDSPEED;
	public static double LEVEL_TIME;
	public static int CURRENT_LEVEL = 1;
	public static bool DEAD = false;
	
	
	
	public GameObject scoreBoardPanel;
	private Text scoreBoard;
	
	public GameObject levelPanel;
	private Text currentLevel;
	
	public GameObject retriesPanel;
	private Text retriesBoard;
	private Scene currentScene;
	








	void Start()
	{
		
		currentLevel = levelPanel.GetComponent<Text>();		
		scoreBoard = scoreBoardPanel.GetComponent<Text>();
		retriesBoard = retriesPanel.GetComponent<Text>();
		currentScene = SceneManager.GetActiveScene();
		
		
	}
	


    void Update()
    {

		PlayerStats.CURRENT_LEVEL = System.Int32.Parse(currentScene.name);


		currentLevel.text = (PlayerStats.CURRENT_LEVEL).ToString();
		scoreBoard.text = (PlayerStats.PLAYER_SCORE).ToString();
		retriesBoard.text = (PlayerStats.PLAYER_RETRIES).ToString();
		
    }
}
