using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
	
	public Text theScoreBoard;

	
    void Start()
    {
        theScoreBoard.text = (PlayerStats.PLAYER_SCORE).ToString();
    }
	
	
	
}
