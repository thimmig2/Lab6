using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class Enemy : MonoBehaviour {

	protected float health;
	protected float speed;
	protected float regen;
	protected float dropProbability;
	protected float createdAt = Time.fixedTime;

	protected List<Vector3> waypoints; 

	private bool dying = false;
	private int maxExplosion = 10;
	private int explosion = 10;

	public static GameObject Create(GameObject enemyPrefab, Transform parent, List<Vector3> waypoints){
		GameObject enemy = Instantiate(enemyPrefab, waypoints[0] * 2, Quaternion.LookRotation(Vector3.back)) as GameObject;
		Enemy enemyScript = enemy.GetComponent<Enemy>();

		enemy.transform.parent = parent;
		enemyScript.waypoints = waypoints;

		return enemy;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(waypoints.Count > 0) {
			this.travelPath();
		}
	}

	private float getRelativeTime() {
		return Time.fixedTime - this.createdAt;
	}

	public void travelPath() {
		int segment = (int)this.getRelativeTime() % this.waypoints.Count;
		float u = (this.getRelativeTime() % 1);

		Vector3 point = new Vector3();	
		Vector3 point0 = waypoints[(segment - 1) > 0 ? segment : waypoints.Count - 1];
		Vector3 point1 = waypoints[segment];
		Vector3 point2 = waypoints[(segment + 1) % waypoints.Count];
		Vector3 point3 = waypoints[(segment + 2) % waypoints.Count];
		
		float tension = .5F;
		point = (point1 +
				(-1 * tension * point0 + tension * point2) * u +
				(tension * 2 * point0 + (tension - 3) * point1 + (3 - (2 * tension)) * point2 - tension * point3) * (float)Math.Pow(u, 2) +
				(-1 * tension * point0 + (2 - tension) * point1 + (tension - 2) * point2 + tension * point3) * (float)Math.Pow(u, 3));
		
		transform.localPosition = point;
	}

	public void applyDamage(float damage) {
		health -= damage;
		if(!this.dying && health <= 0) {
			this.die();
		}
	}

	public void die() {
		this.dropPowerup();
		Destroy(collider);
		Destroy(renderer);
		for(int i = 0; i < UnityEngine.Random.Range(4, 15); i++) {
			ExplosionScript.Create(gameObject);
		}
	}

	public void dropPowerup() {
		if(UnityEngine.Random.value <= dropProbability) {
			GameObject powerup = Instantiate(Resources.Load("Powerup", typeof(GameObject)), transform.position, transform.rotation) as GameObject;
			powerup.renderer.material.color = Color.blue;
		}
	}
}
