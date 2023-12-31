using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public HighScoreScript highScoreScript; // Reference to your HighScoreScript

    // Call this method when the game is over and pass the final score
    public void EndGame(int finalScore)
    {
        // Call the GameOver method in HighScoreScript with the final score
        highScoreScript.GameOver(finalScore);
    }
}
