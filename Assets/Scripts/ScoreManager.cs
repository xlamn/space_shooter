using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class ScoreData
{
    public List<ScoreEntry> highScores = new List<ScoreEntry>();
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private const string highScoresKey = "HighScores";
    private const int maxEntries = 5;

    public ScoreData scoreData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadHighScores();
    }

    public void LoadHighScores()
    {
        // Load high scores from PlayerPrefs
        string highScoresJson = PlayerPrefs.GetString(highScoresKey, "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(highScoresJson);

        // If there are no high scores yet, initialize the list
        if (scoreData == null || scoreData.highScores == null)
        {
            scoreData = new ScoreData();
            scoreData.highScores = new List<ScoreEntry>();
        }
    }

    public void SaveHighScores()
    {
        // Sort the list in descending order
        scoreData.highScores.Sort((a, b) => b.score.CompareTo(a.score));

        // Keep only the top entries (up to maxEntries)
        scoreData.highScores = scoreData.highScores.Take(maxEntries).ToList();

        // Save high scores to PlayerPrefs;
        string highScoresJson = JsonUtility.ToJson(scoreData);

        PlayerPrefs.SetString(highScoresKey, highScoresJson);
        PlayerPrefs.Save();
    }

    public void AddScore(int score)
    {
        // Add a new score entry to the list
        scoreData.highScores.Add(new ScoreEntry(score));

        // Save the updated high scores list
        SaveHighScores();
    }
}