using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjects : MonoBehaviour
{
    public GameObject _Object;
    public void respawn()
    {
        StartCoroutine(respawnRoutine());
    }
    public IEnumerator respawnRoutine()
    {
        yield return new WaitForSeconds(20);
        GameObject instance = Instantiate(_Object, transform.position, transform.rotation);
        instance.transform.parent = transform;
    }
}
