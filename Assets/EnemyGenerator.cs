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
		StartCoroutine(spawnEnemiesMethod(difficultySeed));
	}

	IEnumerator spawnEnemiesMethod(int difficultySeed) {
		enemies = new List<GameObject>();
		for(int count = 0; count < 100; count++) {
			List<Vector3> waypoints = new List<Vector3>();

			waypoints.Add(new Vector3(-2.5F, 0F, 2.5F));
			waypoints.Add(new Vector3(0F, 0F, 0F));
			waypoints.Add(new Vector3(2.5F, 0F, 2.5F));
			waypoints.Add(new Vector3(0F, 0F, 0F));
			waypoints.Add(new Vector3(2.5F, 0F, -2.5F));
			waypoints.Add(new Vector3(0F, 0F, 0F));
			waypoints.Add(new Vector3(-2.5F, 0F, -2.5F));

			yield return new WaitForSeconds (1);
			enemies.Add(Enemy.Create(enemyPrefabs[0], transform, waypoints));			
		}
	}

	public void clearEnemies() {
		foreach(GameObject enemy in enemies) {
			Destroy(enemy);
		}
	}
}
