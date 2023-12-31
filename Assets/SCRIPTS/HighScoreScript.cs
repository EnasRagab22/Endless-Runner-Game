using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScoreScript : MonoBehaviour
{
    public Transform container;
    public Transform template;

    private List<HighscoreEntry> HighscoreEntryList;
    private List<Transform> HighscoreTransformList;

    private void Awake()
    {
        if (container == null || template == null)
        {
            Debug.LogError("Please assign the container and template in the inspector!");
            return;
        }

        template.gameObject.SetActive(false);

        LoadHighScoresFromFile();
    }

    private void LoadHighScoresFromFile()
    {
        string filePath = Application.persistentDataPath + "/HighScoreTable.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);  

            HighscoreEntryList = new List<HighscoreEntry>();

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length >= 2)
                {
                    int score;
                    if (int.TryParse(values[0], out score))
                    {
                        HighscoreEntry entry = new HighscoreEntry { score = score, name = values[1] };
                        HighscoreEntryList.Add(entry);
                    }
                }
            }

            SortHighScores();
            DisplayHighScores();
        }
        else
        {
            Debug.Log(Application.persistentDataPath);
            Debug.LogWarning("No saved high score file found.");
            HighscoreEntryList = new List<HighscoreEntry>();
        }
    }

    private void SaveHighScoresToFile()
    {
        string filePath = Application.persistentDataPath + "/HighScoreTable.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (HighscoreEntry entry in HighscoreEntryList)
            {
                writer.WriteLine(entry.score + "," + entry.name);
            }
        }
    }

    private void SortHighScores()
    {
        HighscoreEntryList.Sort((x, y) => y.score.CompareTo(x.score));
    }

    private void DisplayHighScores()
    {
        HighscoreTransformList = new List<Transform>();
        for (int i = 0; i < HighscoreEntryList.Count; i++)
        {
            CreateHighscoreEntryTransform(HighscoreEntryList[i], container, HighscoreTransformList, i + 1);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscore, Transform container, List<Transform> transformlist, int rank)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(template, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformlist.Count);
        entryTransform.gameObject.SetActive(true);

        string rankString = GetRankString(rank);
        entryTransform.Find("titleText").GetComponent<Text>().text = rankString;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = highscore.score.ToString();
        entryTransform.Find("NameText").GetComponent<Text>().text = highscore.name;

        transformlist.Add(entryTransform);
    }

    private string GetRankString(int rank)
    {
        switch (rank)
        {
            default: return rank + "TH";
            case 1: return "1ST";
            case 2: return "2ND";
            case 3: return "3RD";
        }
    }

    public void AddHighScoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry() { name = name, score = score };
        HighscoreEntryList.Add(highscoreEntry);
        SortHighScores();
        SaveHighScoresToFile();
        DisplayHighScores();
    }

    public void GameOver(int finalScore)
    {
        if (HighscoreEntryList.Count < 10 || finalScore > HighscoreEntryList[HighscoreEntryList.Count - 1].score)
        {
            AddHighScoreEntry(finalScore, "PlayerName"); // Replace "PlayerName" with the actual player's name
        }
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
