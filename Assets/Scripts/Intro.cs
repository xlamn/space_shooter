using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadRankingScene()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }


}
