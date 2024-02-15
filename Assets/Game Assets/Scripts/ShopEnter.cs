using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnter : MonoBehaviour
{
    public GameObject button;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.SetActive(false);
        }
    }

    
}
