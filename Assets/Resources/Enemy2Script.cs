using UnityEngine;
using System.Collections;

public class Enemy2Script : Enemy {

	// Use this for initialization
	void Start () {
		this.health = 20;
		this.speed = 15;
		this.regen = 1;
		this.dropProbability = .1F;
		transform.rotation = Quaternion.Euler(90, 180, 0);
	}

	public override void shootAtPlayer() {
		if(Random.Range(0, 1) < .2) {
			BulletScript.Create(false, 4, transform);
		}
	}
	
}
