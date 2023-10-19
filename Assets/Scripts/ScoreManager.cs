using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI scoreUI;
    int totalScore = 0;

    private void Awake()
    {
        if (scoreManager == null)
        {
            scoreManager = this;
        }
        scoreUI.text = "Score: 0";
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        scoreUI.text = "Score: " + totalScore.ToString();
    }

    /*
    public TMP_Text coinText;
    public static int coinTotal = 0;

    private void Start()
    {
        coinText.text = "Coins: 0";
    }

    private void Update()
    {
        coinText.text = "Coins: " + coinTotal;
    }

    public static void UpdateScore()
    {
        coinTotal++;
    }
    */
}
