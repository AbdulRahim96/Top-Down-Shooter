using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPos : MonoBehaviour
{

    public Transform turretPos;
    public Transform turretObject;
    // Start is called before the first frame update
    void Start()
    {
        turretObject.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        turretObject.position = turretPos.position;
    }
}
