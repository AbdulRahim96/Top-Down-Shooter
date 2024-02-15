using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetup : MonoBehaviour
{
    public float[] rateOfFire, damage;
    public int[] clip, magazine;

    public int rate, dmg, clp, mag;

    public string upgradeFireRate()
    {
        rate++;
        string price;
        if (rate < rateOfFire.Length)
        {
            price = (rateOfFire[rate] * 1000).ToString("0");
            return price;
        }
        rate = rateOfFire.Length - 1;
        return "max";
    }

    public string upgradeDamage()
    {
        dmg++;
        string price;
        if (dmg < damage.Length)
        {    
            price = (damage[dmg] * 1000).ToString("0");
            return price;
        }
        dmg = damage.Length - 1;
        return "max";
    }

    public string upgradeClip()
    {
        clp++;
        string price;
         if(clp < clip.Length)
        {
            price = (clip[clp] * 10).ToString("0");
            return price;
        }
        clp = clip.Length - 1;
        return "Max";
    }

    public string upgradeMag()
    {
        mag++;
        string price;
        if(mag < magazine.Length)
        {
            price = (magazine[mag] * 10).ToString("0");
            return price;
        }
        mag = magazine.Length - 1;
        return "Max";
    }
}
