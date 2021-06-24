using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour
{
	
	
	public GameObject buttonBack;
	public GameObject buttonNext;
	public GameObject tutorialImageOne;
	public GameObject tutorialImageTwo;
	public GameObject tutorialImageThree;
	public GameObject tutorialImageFour;
	public GameObject quitScreen;
	public Text quitScreenTitle;
	public GameObject quitButton;
	private int pageNumber = 1;


	public void ChoosePage(int pageNumberSelected)
	{
		if (pageNumberSelected == 1)
		{
			pageNumber = pageNumber + 1;
		}

		else if (pageNumberSelected == 0)
		{
			pageNumber = pageNumber - 1;
		}

		Debug.Log(pageNumber);

		if (pageNumber == 1)
		{
			buttonBack.GetComponent<CanvasGroup>().alpha = 0.0f;
			buttonBack.GetComponent<CanvasGroup>().blocksRaycasts = false;


			buttonNext.GetComponent<CanvasGroup>().alpha = 1.0f;
			buttonNext.GetComponent<CanvasGroup>().blocksRaycasts = true;



			tutorialImageOne.GetComponent<CanvasGroup>().alpha = 1.0f;


			tutorialImageTwo.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageThree.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageFour.GetComponent<CanvasGroup>().alpha = 0.0f;
			tutorialImageFour.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		if (pageNumber == 2)
		{

			buttonBack.GetComponent<CanvasGroup>().alpha = 1.0f;
			buttonBack.GetComponent<CanvasGroup>().blocksRaycasts = true;


			buttonNext.GetComponent<CanvasGroup>().alpha = 1.0f;
			buttonNext.GetComponent<CanvasGroup>().blocksRaycasts = true;



			tutorialImageOne.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageTwo.GetComponent<CanvasGroup>().alpha = 1.0f;


			tutorialImageThree.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageFour.GetComponent<CanvasGroup>().alpha = 0.0f;
			tutorialImageFour.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		if (pageNumber == 3)
		{



			buttonBack.GetComponent<CanvasGroup>().alpha = 1.0f;
			buttonBack.GetComponent<CanvasGroup>().blocksRaycasts = true;


			buttonNext.GetComponent<CanvasGroup>().alpha = 1.0f;
			buttonNext.GetComponent<CanvasGroup>().blocksRaycasts = true;


			tutorialImageOne.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageTwo.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageThree.GetComponent<CanvasGroup>().alpha = 1.0f;

			tutorialImageFour.GetComponent<CanvasGroup>().alpha = 0.0f;
			tutorialImageFour.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		if (pageNumber == 4)
		{



			buttonBack.GetComponent<CanvasGroup>().alpha = 1.0f;
			buttonBack.GetComponent<CanvasGroup>().blocksRaycasts = true;


			buttonNext.GetComponent<CanvasGroup>().alpha = 0.0f;
			buttonNext.GetComponent<CanvasGroup>().blocksRaycasts = false;


			tutorialImageOne.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageTwo.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageThree.GetComponent<CanvasGroup>().alpha = 0.0f;


			tutorialImageFour.GetComponent<CanvasGroup>().alpha = 1.0f;
			tutorialImageFour.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}



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
