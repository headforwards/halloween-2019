using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        gameState.Animator.SetBool("playing", true);
    }

    public static void GameOver()
    {
        if (!isPlaying)
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
        gameState.Animator.SetBool("playing", true);

    }

    void SetSurvivalText(string message)
    {
        if (gameState.SurvivalTime != null)
        {
            gameState.SurvivalTime.text = message;
            gameState.Animator.SetBool("playing", false);
            StartCoroutine(ClearText());
        }
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(DisplayScoreTime);
        if (gameState.SurvivalTime != null)
        {
            gameState.Animator.SetBool("playing", true);
        }
    }

    public TMP_Text SurvivalTime;

    public Animator Animator;
}
