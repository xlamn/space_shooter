using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject scoreRowObject;
    public Canvas canvas;
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        for (int i = 0; i < scoreManager.scoreData.highScores.Count; i++)
        {
            GameObject newObject = Instantiate(scoreRowObject, canvas.transform);
            UseScoreData(newObject, i);

            newObject.transform.localPosition = new Vector3(0, 100 - (i * 50), transform.position.z);
            newObject.transform.localRotation = Quaternion.identity;

        }
    }

    void UseScoreData(GameObject rowObject, int i)
    {
        Transform textObject1 = rowObject.transform.Find("Time");
        if (textObject1 != null)
        {
            TextMeshProUGUI textMeshPro1 = textObject1.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro1 != null)
            {
                textMeshPro1.text = scoreManager.scoreData.highScores[i].timestamp;
            }
        }

        Transform textObject2 = rowObject.transform.Find("Score");
        if (textObject2 != null)
        {
            TextMeshProUGUI textMeshPro2 = textObject2.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro2 != null)
            {
                textMeshPro2.text = scoreManager.scoreData.highScores[i].score.ToString();
            }
        }
    }
}
