using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour
{
	
	
	public GameObject backButton;
	public GameObject nextButton;
	public GameObject tutorialImageOne;
	public GameObject tutorialImageTwo;
	public GameObject quitScreen;
	public Text quitScreenTitle;
	public GameObject quitButton;
	
	
    // Start is called before the first frame update
    void Start()
    {
		
	
		
        
    }




	public void OnClickNext()
	{
		
		backButton.GetComponent<CanvasGroup>().alpha = 1.0f;
		backButton.GetComponent<CanvasGroup>().blocksRaycasts = true;
		
		
		nextButton.GetComponent<CanvasGroup>().alpha = 0.0f;
		nextButton.GetComponent<CanvasGroup>().blocksRaycasts = false;
		
		
		tutorialImageOne.GetComponent<CanvasGroup>().alpha = 0.0f;
		
		
		tutorialImageTwo.GetComponent<CanvasGroup>().alpha = 1.0f;

		
	}


	public void OnClickBack()
	{
		
		backButton.GetComponent<CanvasGroup>().alpha = 0.0f;
		backButton.GetComponent<CanvasGroup>().blocksRaycasts = false;
		
		
		nextButton.GetComponent<CanvasGroup>().alpha = 1.0f;
		nextButton.GetComponent<CanvasGroup>().blocksRaycasts = true;
		
		
		tutorialImageOne.GetComponent<CanvasGroup>().alpha = 1.0f;
		
		
		tutorialImageTwo.GetComponent<CanvasGroup>().alpha = 0.0f;

		
	}

	
	public void DoGameQuit()
	{   

		quitScreen.GetComponent<CanvasGroup>().alpha = 1.0f;
		quitScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
		
		
		quitButton.GetComponent<CanvasGroup>().alpha = 0.0f;
		quitButton.GetComponent<CanvasGroup>().blocksRaycasts = false;
		
		
		quitScreenTitle.text = "Quit Game";

		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
	}
	
	
	public void DoResume()
	{   
		quitScreen.GetComponent<CanvasGroup>().alpha = 0.0f;
		quitScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		
		
		quitButton.GetComponent<CanvasGroup>().alpha = 1.0f;
		quitButton.GetComponent<CanvasGroup>().blocksRaycasts = true;


		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
	}

}
