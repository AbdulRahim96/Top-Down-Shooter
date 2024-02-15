using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

	public float speed;
	public float fireRate;
	public GameObject muzzlePrefeb;
	public GameObject hitPrefeb;

	// Use this for initialization
	void Start () {
		if (muzzlePrefeb != null) {
			var muzzleVFX = Instantiate (muzzlePrefeb, transform.position, Quaternion.identity);
			muzzleVFX.transform.forward = gameObject.transform.forward;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (speed != 0) {
			transform.position += transform.forward * (speed * Time.deltaTime);
		}
		else {
			Debug.Log ("No fire point");
		}
	}
	void OnCollisionEnter (Collision co){
		speed = 0;

		ContactPoint contact = co.contacts [0];
		Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
		Vector3 pos = contact.point;

		if (hitPrefeb != null) {
			var hitVFX = Instantiate (hitPrefeb, pos, rot);
		}

		Destroy (gameObject);
	
	}
}
