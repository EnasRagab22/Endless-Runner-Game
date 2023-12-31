using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private List<Score> scores = new List<Score>();

    public IEnumerable<Score> GetHieghScore()
    {
        return scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        scores.Add(score);
    }

    public int GetScoreRank(Score score)
    {
        return scores.OrderByDescending(x => x.score).ToList().IndexOf(score);
    }
}
