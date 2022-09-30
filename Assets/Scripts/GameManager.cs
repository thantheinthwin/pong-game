using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    public scoreText scoreTextLeft, scoreTextRight;
    public GameObject titleScreen;

    public void onScoreZoneReached(int id)
    {
        if(id == 1)
        {
            scorePlayer1++;
        }

        if(id == 2)
        {
            scorePlayer2++;
        }

        updateScore();
    }

    public void updateScore()
    {
        scoreTextLeft.setScore(scorePlayer1);
        scoreTextRight.setScore(scorePlayer2);
    }

    public void gameOver()
    {
        
    }
}
