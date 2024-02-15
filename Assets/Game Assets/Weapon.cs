using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject cannonObject, muzzleEffects;
    public float speed, damage = 5;

    public void Fire()
    {
        Instantiate(muzzleEffects, firePoint.position, firePoint.rotation);
        GameObject obj = Instantiate(cannonObject, firePoint.position, firePoint.rotation);
        obj.GetComponent<Bullet>().speed = this.speed;
        obj.GetComponent<Bullet>().damage = this.damage;
    }
}
