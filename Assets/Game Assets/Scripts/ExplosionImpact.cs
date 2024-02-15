using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionImpact : MonoBehaviour
{
    public float explosionIntensity, radius, power = 50;

    private void Start()
    {
        knockBack(radius, explosionIntensity);
    }
    public void knockBack(float x_radius, float x_explosionIntensity)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, x_radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();

            if(rb != null)
            {
                
                rb.useGravity = true;
                rb.AddExplosionForce(x_explosionIntensity, transform.position, x_radius);
            }
            float damage = Vector3.Distance(transform.position, nearby.transform.position);
            if (nearby.tag == "Player")
            {
                var health = nearby.gameObject.GetComponent<Health>();
                
                health.maxDamage -= power / damage;
                health.healthBar.value = health.maxDamage;
                health.damageUpdate();
                Debug.Log("damage: " + power / damage);
            }
            if (nearby.tag == "enemy")
            {
                var health = nearby.gameObject.GetComponent<Enemies>();
                health.maxDamage -= power / damage;
                health.healthBar.value = health.maxDamage;
                health.damageUpdate();
                Debug.Log("damage: " + power / damage);
            }


        }

    }
}
