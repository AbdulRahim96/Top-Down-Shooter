using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour
{
    public RespawnObjects respawnObjects;
    [SerializeField] [Range(1f, 50f)] private float power;
    public Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= power)
        transform.position = Vector3.MoveTowards(transform.position, player.position, 0.7f * power);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawnObjects.respawn();
            var sound = FindObjectOfType<Sounds>();
            sound.Play("pickup");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Enemy_Spawn_Manager.credits += 10;
    }

}
