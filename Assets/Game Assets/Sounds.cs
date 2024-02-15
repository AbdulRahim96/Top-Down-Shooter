using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip click, gunFire, reload, weaponPickup;
    [SerializeField] private AudioSource source;
    public void Play(string name)
    {
        switch (name)
        {
            case "click": source.clip = click;
                          source.Play();
                          break;
            case "gunFire": source.clip = gunFire;
                          source.Play();
                          break;
            case "reload": source.clip = reload;
                          source.Play();
                          break;
            case "pickup": source.clip = weaponPickup;
                          source.Play();
                          break;

        }
    }

    
}
