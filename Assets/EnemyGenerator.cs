using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGenerator : MonoBehaviour {

	public List<GameObject> enemyPrefabs;
	private List<GameObject> enemies;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnEnemies(int difficultySeed) {
		enemies = new List<GameObject>();
		for(int count = 0; count < 10; count++) {
			GameObject enemy = Instantiate(enemyPrefabs[0], transform.position, transform.rotation) as GameObject;
			enemies.Add(enemy);
		}
	}

	public void clearEnemies() {
		foreach(GameObject enemy in enemies) {
			Destroy(enemy);
		}
	}
}
