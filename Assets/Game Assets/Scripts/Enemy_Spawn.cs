using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawn : MonoBehaviour
{

    public float RespawnTime = 5;
    private float reset;
    public GameObject enemies;

    void Start()
    {
        reset = RespawnTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RespawnTime -= Time.deltaTime;
        if (RespawnTime <= 0)
        {
            SpawnEnemies();
            RespawnTime = reset;
        }
    }

    public void SpawnEnemies()
    {
        if (Enemy_Spawn_Manager.enemiesLeftToSpawn > 0 && Enemy_Spawn_Manager.start && Enemy_Spawn_Manager.totalCurrentEnemies <= Enemy_Spawn_Manager.zombieLimit)
        {
            Enemy_Spawn_Manager.enemiesLeftToSpawn--;
            GameObject obj = Instantiate(enemies, transform.position, transform.rotation);
            var Enemy = obj.GetComponent<Enemies>();
            Enemy.maxDamage += Enemy_Spawn_Manager.maxHealth;
        }
    }
}
