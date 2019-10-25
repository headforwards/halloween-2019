using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static bool isPlaying;
    public static int enemyCount;

    public float DisplayScoreTime = 10f;

    static GameState gameState;

    static DateTime start = DateTime.Now;

    void Start()
    {
        gameState = this;
        gameState.SetSurvivalText(string.Empty);
        Debug.Log("s");
    }

    public static void GameOver()
    {
        if(!isPlaying)
            return;

        isPlaying = false;
        enemyCount = 0;

        int seconds = Convert.ToInt32((DateTime.Now - start).TotalSeconds);

        gameState.SetSurvivalText(
            string.Format("You survived for {0} seconds",
            seconds));
    }

    public static void StartGame()
    {
        isPlaying = true;
        enemyCount = 0;
        start = DateTime.Now;
    }

    void SetSurvivalText(string message)
    {
        if (gameState.SurvivalTime != null)
        {
            gameState.SurvivalTime.text = message;
            StartCoroutine(ClearText());
        }
    }

    IEnumerator ClearText()
    {
        Debug.Log("c");
        yield return new WaitForSeconds(DisplayScoreTime);
        if (gameState.SurvivalTime != null)
        {
            gameState.SurvivalTime.text = string.Empty;
        }
    }

    public Text SurvivalTime;

}
