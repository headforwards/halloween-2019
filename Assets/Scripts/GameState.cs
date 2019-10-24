using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool isPlaying ;
    public static int enemyCount;

    public static void GameOver()
    {
        isPlaying = false;
        enemyCount = 0;
    }

    public static void StartGame(){
        isPlaying = true;
        enemyCount = 0;
    }

}
