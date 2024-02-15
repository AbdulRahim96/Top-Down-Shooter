using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : Health
{
    public Material targetMat;
    public Weapon enemyWeapon;
    public NavMeshAgent agent;
    public Transform player;
    public Animator animation;
    public Material normal, highlighted;
    public GameObject hand;
    public AudioClip chase, attack;
    [SerializeField] private AudioSource sound;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInAttackange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar.maxValue = maxDamage;
        healthBar.value = maxDamage;
    }
    private void OnMouseDown()
    {
        FindObjectOfType<TopDownCharacterMover>().target = transform;
        normal = targetMat;
        
    }

    private void Update()
    {
        agent.enabled = !isDead;

        if(!isDead)
        {
            if (Vector3.Distance(transform.position, player.position) > agent.stoppingDistance + 0.5f)
                chasePlayer();
            else
                attackPlayer();
        }
    }

    public void attackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        animation.SetBool("fire", true);
        animation.SetBool("chase", false);

        sound.clip = attack;


      /*  if(!alreadyAttacked)
        {
            enemyWeapon.Fire();
            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }*/
    }

    public void chasePlayer()
    {
        agent.SetDestination(player.position);
        animation.SetBool("chase", true);
        animation.SetBool("fire", false);

        sound.clip = chase;
    }

    void resetAttack()
    {
        alreadyAttacked = false;
    }

    public void hide()
    {
        hand.SetActive(false);
    }

    public void show()
    {
        hand.SetActive(true);
        hand.GetComponent<AudioSource>().Play();
    }
    private void OnDestroy()
    {
        Enemy_Spawn_Manager.score += (500 * Enemy_Spawn_Manager.currentRound);
    }
}
