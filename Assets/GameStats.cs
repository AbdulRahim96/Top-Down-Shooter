using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    public Text time, zombieKilled, score, highscore;
    void Start()
    {
        
        int seconds = ((int)Enemy_Spawn_Manager.gameTime % 60);
        int minutes = ((int)Enemy_Spawn_Manager.gameTime / 60) % 60;

        string format = string.Format("{0:00}:{1:00}", minutes, seconds);

        time.text = "Total Time - " + format;
        zombieKilled.text = "Zombies killed - " + Enemy_Spawn_Manager.zombiekilled;
        Enemy_Spawn_Manager.score += (int)(Enemy_Spawn_Manager.gameTime*1.5f);

        score.text = "Total Score - " + Enemy_Spawn_Manager.score;

        int oldScore = PlayerPrefs.GetInt("highscore", 0);
        highscore.text = "Current Best - " + oldScore.ToString("0");
        if(Enemy_Spawn_Manager.score > oldScore)
        {
            PlayerPrefs.SetInt("highscore", Enemy_Spawn_Manager.score);
            highscore.text = "New High Score!";
            highscore.color = Color.green;
        }
    }

    
}
