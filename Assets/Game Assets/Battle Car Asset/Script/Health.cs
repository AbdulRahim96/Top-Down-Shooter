using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxDamage;
    public Slider healthBar;
    public GameObject blood;
    public GameObject[] afterDestroyed;
    protected bool isDead = false;
    public bool isPlayer = false;
    // Update is called once per frame
    private void Start()
    {
        healthBar.maxValue = maxDamage;
        healthBar.value = maxDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            maxDamage -= collision.gameObject.GetComponent<Bullet>().takenDamage();
            healthBar.value = maxDamage;
            Instantiate(blood, transform.position, transform.rotation);
            damageUpdate();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("trigger");
            maxDamage -= collision.gameObject.GetComponent<Bullet>().takenDamage();
            healthBar.value = maxDamage;
            Instantiate(blood, transform.position, transform.rotation);
            damageUpdate();
        }
    }

    public void damageUpdate()
    {
        if (!isDead)
        {
            if (maxDamage <= 0)
            {
                Debug.Log("killed");
                isDead = true;
                if (isPlayer)
                    InputHandler.gameOver = true;
                else
                    Enemy_Spawn_Manager.zombiekilled++;
                int random = Random.Range(0, afterDestroyed.Length);
                if (random < 4)
                    Instantiate(afterDestroyed[random], transform.position, transform.rotation);
                GetComponent<Animator>().SetBool("die", true);
                gameObject.tag = "Untagged";
                healthBar.gameObject.SetActive(false);
                Enemy_Spawn_Manager.credits += (50 *Enemy_Spawn_Manager.currentRound);
                Destroy(gameObject, 5);
            }
        }
    }
}
