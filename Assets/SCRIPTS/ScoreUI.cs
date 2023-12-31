//scoreManager.AddScore(new Score("player",6));
//scoreManager.AddScore(new Score("player2", 7));
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    public GAME_OVER game_over; 

    void Start()
    {
        game_over = GetComponent<GAME_OVER>();

        if (game_over != null)
        {
            int score = game_over.GameOver();
            SaveCoinsCollected(score);
        }
        else
        {
            Debug.LogWarning("GAME_OVER object not found!");
        }
        SaveCoinsCollected(10);
        //DisplayScores();
    }

    public void DisplayScores()
    {
        var scores = scoreManager.GetHieghScore().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.name.text = scores[i].name;
            row.Score.text = scores[i].score.ToString();
        }
    }

    public void SaveCoinsCollected(int coinsCollected)
    {
        scoreManager.AddScore(new Score("player", coinsCollected));
        DisplayScores(); 
    }
}
