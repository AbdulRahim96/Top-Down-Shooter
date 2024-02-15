using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Slider rateOfFire, power, clip, magazine;

    private WeaponSetup currentWeapon;
    public Text name, rateText, powerText, clipText, magazineText, moneyText;
    public int rate, pow, clp, mag;

    private AudioSource audio;
    void Start()
    {
        switchGun("Pistol");
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        moneyText.text = "$" + Enemy_Spawn_Manager.credits.ToString("0");
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        Cannon Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Cannon>();
        Player.updateStats(Player.currentWeapon);
    }

    public void switchGun(string weaponName)
    {
        currentWeapon = GameObject.Find(weaponName).GetComponent<WeaponSetup>();
        name.text = weaponName;
        rateOfFire.value = currentWeapon.rateOfFire[currentWeapon.rate];
        power.value = currentWeapon.damage[currentWeapon.dmg];
        clip.value = currentWeapon.clip[currentWeapon.clp];
        magazine.value = currentWeapon.magazine[currentWeapon.mag];

        rateText.text = (rateOfFire.value * 250).ToString("0");
        rate = int.Parse(rateText.text);

        powerText.text = (power.value * 250).ToString("0");
        pow = int.Parse(powerText.text);

        clipText.text = (clip.value * 10).ToString("0");
        clp = int.Parse(clipText.text);

        magazineText.text = (magazine.value * 10).ToString("0");
        mag = int.Parse(magazineText.text);
    }

    public void upgradeFireRate()
    {
        if(rate <= Enemy_Spawn_Manager.credits)
        {
            rateText.text = currentWeapon.upgradeFireRate();
            rate = int.Parse(rateText.text);
            rateOfFire.value = currentWeapon.rateOfFire[currentWeapon.rate];
            Enemy_Spawn_Manager.credits -= rate;
            moneyText.text = "$" + Enemy_Spawn_Manager.credits.ToString("0");
            audio.Play();
        }
    }

    public void upgradeDamage()
    {
        if (pow <= Enemy_Spawn_Manager.credits)
        {
            powerText.text = currentWeapon.upgradeDamage();
            pow = int.Parse(powerText.text);
            power.value = currentWeapon.damage[currentWeapon.dmg];
            Enemy_Spawn_Manager.credits -= pow;
            moneyText.text = "$" + Enemy_Spawn_Manager.credits.ToString("0");
            audio.Play();
        }
    }

    public void upgradeClip()
    {
        if (clp <= Enemy_Spawn_Manager.credits)
        {
            clipText.text = currentWeapon.upgradeClip();
            clp = int.Parse(clipText.text);
            clip.value = currentWeapon.clip[currentWeapon.clp];
            Enemy_Spawn_Manager.credits -= clp;
            moneyText.text = "$" + Enemy_Spawn_Manager.credits.ToString("0");
            audio.Play();
        }
    }

    public void upgradeMag()
    {
        if(mag <= Enemy_Spawn_Manager.credits)
        {
            magazineText.text = currentWeapon.upgradeMag();
            mag = int.Parse(magazineText.text);
            magazine.value = currentWeapon.magazine[currentWeapon.mag];
            Enemy_Spawn_Manager.credits -= mag;
            moneyText.text = "$" + Enemy_Spawn_Manager.credits.ToString("0");
            audio.Play();
        }
    }

    public void purchase()
    {
        Enemy_Spawn_Manager.credits += 50000;
        moneyText.text = "$" + Enemy_Spawn_Manager.credits.ToString("0");
        PlayerPrefs.SetInt("ads", 0);
        audio.Play();
    }
}
