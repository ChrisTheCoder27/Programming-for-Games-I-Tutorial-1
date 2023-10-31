using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public string nameCollectable;
    public int score;

    public int restoreHp;

    public Collectables(string name, int scoreValue, int restoreHpValue)
    {
        this.nameCollectable = name;
        this.score = scoreValue;
        this.restoreHp = restoreHpValue;
    }

    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
    }

}
