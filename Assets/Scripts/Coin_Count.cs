using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin_Count : MonoBehaviour
{
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
}
