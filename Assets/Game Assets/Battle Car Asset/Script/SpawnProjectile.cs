using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour {


	public GameObject firePoint; 
	public List<GameObject> vfx = new List<GameObject> ();
	//public RotateToMouse rotateToMouse;
	public AudioClip fireSound;
	public AudioSource source;

	private GameObject effectToSpawn;
	private float timeToFire = 0;
	// Use this for initialization
	void Start () {
		effectToSpawn = vfx [0];
		source.clip = fireSound;
	}
	
	// Update is called once per frame
	public void fire() {
		if (Input.GetMouseButton (0) && Time.time >= timeToFire) {
			timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove> ().fireRate;

			source.Play ();

		}
		
	}
	


  }
