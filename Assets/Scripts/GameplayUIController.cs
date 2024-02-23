using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    private float score;
    private float highScore;

    private string filePath;

    private bool hasRun;

    public TMP_Text ScoreUI;
    public TMP_Text HighScoreUI;

    public void RestartGame() {

        SceneManager.LoadScene("Gameplay");

        // SceneManager.LoadScene(SceneMangaer.GetActiveScene().name);

    }


    public void HomeButton() {
        SceneManager.LoadScene("MainMenu");
    }
    private void Awake()
    {

        string entireFile = "";
        string file = "HighScore.txt";

        filePath = Path.Combine(Application.dataPath, file);
        if (File.Exists(filePath))
        {
            entireFile = File.ReadAllText(filePath);

        }

        score = 0;
        if(entireFile.Length!=0)
        {
            highScore = float.Parse(entireFile);
        }
        else
        {
            highScore = 0;
        }
       

        HighScoreUI.enabled = false;
        hasRun = false;


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player 1(Clone)")!=null|| GameObject.Find("Player 2(Clone)") != null)
        {
            score += 0.01f;
            ScoreUI.text = Math.Floor(score) + "";
        }
        else
        {
            if(hasRun == false)
            {
                if (score > highScore)
                {
                    highScore = score;
                    File.WriteAllText(filePath, highScore+"");
                }

                HighScoreUI.text += " " + highScore;
                HighScoreUI.enabled = true;

                hasRun = true;
            }
            
        }
    }

}
