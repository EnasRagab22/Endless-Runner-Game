using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAME_OVER : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsCollected;
    public Text obj_text;

    void Start()
    {
        CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString();
        obj_text.text = PlayerPrefs.GetString("Score");
        int currentScore = int.Parse(CoinsCollected.text);
        int savedScore = int.Parse(obj_text.text);

        if (currentScore > savedScore)
        {
            string playerName = PlayerPrefs.GetString("user_name");
            PlayerPrefs.SetString("Score", currentScore.ToString());
            PlayerPrefs.SetString("HighScoreName", playerName); // Update only if score is higher
            PlayerPrefs.Save();
            obj_text.text = "Highest Score: " + currentScore + "\nPlayer: " + playerName;
            Debug.Log("New high score saved: " + currentScore);
        }
        else
        {
            string playerName = PlayerPrefs.GetString("HighScoreName");
            obj_text.text = "Highest Score: " + savedScore + "\nPlayer: " + playerName;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public int GameOver()
    {
        return 10; // You should return the actual final score here
    }

    public void HighScores()
    {
        SceneManager.LoadScene("high");
    }
}
