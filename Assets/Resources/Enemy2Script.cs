using UnityEngine;
using System.Collections;

public class Enemy2Script : Enemy {

	// Use this for initialization
	void Start () {
		this.health = 20;
		this.speed = 15;
		this.regen = 1;
		this.dropProbability = .1F;
	}
	
}
