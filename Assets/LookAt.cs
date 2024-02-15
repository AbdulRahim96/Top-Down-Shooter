using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void FixedUpdate()
    {
        transform.LookAt(camera);
    }
}
