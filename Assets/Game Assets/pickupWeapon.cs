using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupWeapon : MonoBehaviour
{
    public string weaponName;
    public GameObject weapon, fireObject;
    public AudioClip gunFireSound;
    public float speed, fireRate, damage = 5;
    public int clipSize, magazineSize;
    public Sprite icon;

    private void Start()
    {
        WeaponSetup ws = GameObject.Find(weaponName).GetComponent<WeaponSetup>();
        fireRate = ws.rateOfFire[ws.rate];
        damage = ws.damage[ws.dmg];
        clipSize = ws.clip[ws.clp];
        magazineSize = ws.magazine[ws.mag];
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var onHand = other.GetComponent<Cannon>();
            onHand.setWeapon(speed, fireRate, damage, clipSize, magazineSize, weapon, fireObject);
            onHand.icon.sprite = icon;
            onHand.currentWeapon = weaponName;
            var sound = FindObjectOfType<Sounds>();
            sound.Play("pickup");
            sound.gunFire = gunFireSound;
            Destroy(gameObject);
        }
    }
}
