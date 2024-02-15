using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawn_Manager : MonoBehaviour
{
    //Properties
    public static int maxEnemiesPerRound = 5, enemiesLeftToSpawn = 5, totalCurrentEnemies, maxHealth, currentRound = 1, zombieLimit = 40, zombiekilled = 0, score = 0;
    public static float roundgapTime = 5, credits, money, gameTime = 0;
    public static bool start = true;
    public Text round, count, moneyText;
    private static GameObject[] EnemyAmount;
    public GameObject ads;

    private void Start()
    {
        credits = 0;
        money = 0;
        maxEnemiesPerRound = 5;
        enemiesLeftToSpawn = 5;
        maxHealth = 20;
        currentRound = 1;
        zombiekilled = 0;
        score = 0;
        gameTime = 0;
        InputHandler.gameOver = false;
    }
    public IEnumerator roundGap()
    {
        start = false;
        yield return new WaitForSeconds(roundgapTime);
        var obj = Instantiate(ads);
        Destroy(obj, 5);
        yield return new WaitForSeconds(roundgapTime);
        start = true;
    }

    private void FixedUpdate()
    {
        EnemyAmount = GameObject.FindGameObjectsWithTag("enemy");
        totalCurrentEnemies = EnemyAmount.Length;
        round.text = currentRound.ToString("0");
        count.text = "x" + enemiesLeftToSpawn.ToString("0");

        //Next round Logic
        if(enemiesLeftToSpawn == 0 && totalCurrentEnemies == 0)
        {
            nextRound();
        }
        money = Mathf.Lerp(money, credits, 1);
        moneyText.text = "x" + money.ToString("0");

        gameTime += Time.deltaTime;
    }

    public  void nextRound()
    {
        currentRound++;
        maxEnemiesPerRound += 20;
        enemiesLeftToSpawn = maxEnemiesPerRound;
        maxHealth += (currentRound * 2);
        InputHandler.granadeCount = 3;
        StartCoroutine(roundGap());
    }


    public Transform clostest()
    {
        int min = 0;
        Transform Zombie;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < EnemyAmount.Length - 1; i++)
        {
            float closest = Vector3.Distance(player.position, EnemyAmount[min].transform.position);
            float nextDistance = Vector3.Distance(player.position, EnemyAmount[i].transform.position);
            if (nextDistance < closest)
                min = i;
        }
        return EnemyAmount[min].transform;
    }

}
