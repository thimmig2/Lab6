using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour {

	protected float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void travelPath(List<Vector3> waypoints) {

	}

	public void applyDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Destroy(gameObject);
		}
	}
}
