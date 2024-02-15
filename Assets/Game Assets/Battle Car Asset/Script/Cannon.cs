using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : Weapon
{
    public string currentWeapon;
    public GameObject weaponOnHand;
    public Image icon;

    public float reloadSpeed = 2;
    public int clipSize, magazineSize, currentClip, currentMagazineSize;

    public Text clipSizeText, magazineSizeText;

    public string fireButton;
    public float fireRate;
    public static bool canFire = true;
    private float timeToFire = 0;
    private bool firing = false;

    private void Awake()
    {
        updateStats("Pistol");
    }
    public void setWeapon(float spd, float fire, float dmg, int clip, int magazine, GameObject weapon, GameObject fireObj)
    {
        fireRate = fire;
        damage = dmg;
        clipSize = clip;
        magazineSize = magazine;
        cannonObject = fireObj;
        Destroy(GameObject.FindGameObjectWithTag("weapon"));
        GameObject obj = Instantiate(weapon, weaponOnHand.transform.position, weaponOnHand.transform.rotation);
        obj.transform.SetParent(weaponOnHand.transform);

        currentClip = clip;
        currentMagazineSize = magazine;
        if(currentWeapon != "Shotgun")
        speed = spd;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (firing && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Playerfire();
        }

        clipSizeText.text = currentClip.ToString("0") + "/" + clipSize.ToString("0");
        magazineSizeText.text = currentMagazineSize.ToString("0") + "/" + magazineSize.ToString("0");
    }

    void Playerfire()
    {
        if (canFire == true && !InputHandler.gameOver)
        {
            if (currentClip <= 0 && currentMagazineSize <= 0)
            {
                //empty weapon
            }
            else
            {
                if (currentClip <= 0 && currentMagazineSize > 0)
                {
                    reloadWeapon();
                }
                else
                {
                    currentClip--;
                    FindObjectOfType<Sounds>().Play("gunFire");
                    Fire();
                }
            }
        }
        
    }

    public void pointUp()
    {
        firing = false;
    }
    public void pointDown()
    {
        firing = true;
        FindObjectOfType<TopDownCharacterMover>().target = FindObjectOfType<Enemy_Spawn_Manager>().clostest();
    }

    public void updateStats(string weaponName)
    {
        WeaponSetup weaponOnHand = GameObject.Find(weaponName).GetComponent<WeaponSetup>();
        fireRate = weaponOnHand.rateOfFire[weaponOnHand.rate];
        damage = weaponOnHand.damage[weaponOnHand.dmg];
        clipSize = weaponOnHand.clip[weaponOnHand.clp];
        magazineSize = weaponOnHand.magazine[weaponOnHand.mag];
    }

    public void reloadWeapon()
    {
        if (currentClip < clipSize)
        {
            GetComponent<InputHandler>().reload();
            if (currentMagazineSize <= clipSize)
            {
                currentClip = currentMagazineSize;
                currentMagazineSize = 0;
            }
            else
            {
                currentClip = clipSize;
                currentMagazineSize -= clipSize;
            }
        }
    }
}
