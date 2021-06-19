using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
	
	
	public float iniTime;
	public static float TargetTime;


	public float countedTime;
	public static double finalTime;
	
	
	
	public static bool clockStopped = false;
	
	public Text timeTextGui;



	void Start()
	{
		
		TargetTime = iniTime;
		countedTime = 0;
		
	}







	void Update() 
	{     
		if (countedTime < TargetTime)     

		{         
			if (!clockStopped)
			{
				countedTime += Time.deltaTime;     
			}
		}     

		double calculatedTime = System.Math.Round (countedTime, 2);     

		finalTime = calculatedTime;

		timeTextGui.text = calculatedTime.ToString ();     
	}
}