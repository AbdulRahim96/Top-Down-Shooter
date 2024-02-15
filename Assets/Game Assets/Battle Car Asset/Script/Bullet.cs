using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject onCollionEffects;
    public float speed, damage;
    public bool isShotgun = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isShotgun)
        {
            WeaponSetup weaponOnHand = GameObject.Find("Shotgun").GetComponent<WeaponSetup>();
            damage = weaponOnHand.damage[weaponOnHand.dmg];
        }
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(onCollionEffects, transform.position, Quaternion.identity);
        GetComponentInChildren<ParticleSystem>().gameObject.transform.parent = null;
        Destroy(gameObject);
    }

    public float takenDamage()
    {
        return damage;
    }
}
