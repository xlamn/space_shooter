using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class ScoreEntry
{
    public int score;
    public string timestamp;

    public ScoreEntry(int score)
    {
        this.score = score;
        timestamp = DateTime.Now.ToString();
    }
}