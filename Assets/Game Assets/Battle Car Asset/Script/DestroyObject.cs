using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	public float lifetime = 3.0f;

	void Update ()
	{ Destroy (gameObject, lifetime); }
}
