using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Shooter : MonoBehaviour
{
    
    public NavMeshAgent enemyPlayer;
    public Transform followTo;

    public GameObject shootingObject;
    public Transform launchPoint1;
    public Transform launchPoint2;
    public float TimeToShootAtOther;
    public float TimeToShootAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        followTo = GameObject.FindGameObjectWithTag("Cruise").transform;
        TimeToShootAtOther = Random.Range(20f, 40f);
        TimeToShootAtPlayer = Random.Range(20f, 40f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


        TimeToShootAtPlayer -= 1 * Time.deltaTime;
        TimeToShootAtOther -= 1 * Time.deltaTime;


        if (TimeToShootAtPlayer <= 0)
        {
            shootAtPlayer();
            TimeToShootAtPlayer = Random.Range(20f, 40f);
        }
        if(TimeToShootAtOther <= 0)
        {
            shootAtCarrier();
            TimeToShootAtOther = Random.Range(20f, 40f);
        }

        enemyPlayer.SetDestination(followTo.position);
    }

    void shootAtCarrier()
    {

        var target = GameObject.FindGameObjectWithTag("Cruise").transform;

      //  shootingObject.GetComponent<Missile>().target = target;
        Instantiate(shootingObject, launchPoint1.position, launchPoint1.rotation);
    }

    void shootAtPlayer()
    {
        var targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
      //  shootingObject.GetComponent<Missile>().target = targetPlayer;
        Instantiate(shootingObject, launchPoint2.position, launchPoint2.rotation);
        

        
    }
}
