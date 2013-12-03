using UnityEngine;
using System.Collections;

public class Enemy1Script : Enemy {

	// Use this for initialization
	void Start () {
		this.health = 10;
		this.speed = 10;
		this.regen = 1;
		this.dropProbability = .1F;
	}

	public override void shootAtPlayer() {
		if(Random.Range(0, 1) < .1) {
			BulletScript.Create(false, 3, transform);
		}
	}

}
