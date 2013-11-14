using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGenerator : MonoBehaviour {

	public List<GameObject> enemyPrefabs;
	private List<GameObject> enemies;

	private static List<Vector3> path1Cached = null,
		path2Cached = null, 
		path3Cached = null;

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
		for(int count = 0; count < 20; count++) {
			for(int i = 0; i < 40; i++) {
				yield return new WaitForFixedUpdate();
			}
			//yield return new WaitForSeconds (1);
			enemies.Add(Enemy.Create(enemyPrefabs[0], transform, path2()));			
		}
	}

	public void clearEnemies() {
		foreach(GameObject enemy in enemies) {
			Destroy(enemy);
		}
	}

	public static List<Vector3> path1(){
		if(path1Cached == null) {
			path1Cached = new List<Vector3>();
			path1Cached.Add(new Vector3(-2.5F, 0F, 2.5F));
			path1Cached.Add(new Vector3(0F, 0F, 0F));
			path1Cached.Add(new Vector3(2.5F, 0F, 2.5F));
			path1Cached.Add(new Vector3(0F, 0F, 0F));
			path1Cached.Add(new Vector3(2.5F, 0F, -2.5F));
			path1Cached.Add(new Vector3(0F, 0F, 0F));
			path1Cached.Add(new Vector3(-2.5F, 0F, -2.5F));
			path1Cached.Add(new Vector3(0F, 0F, 0F));
		}
		return path1Cached;
	}

	public static List<Vector3> path2(){
		if(path2Cached == null) {
			path2Cached = new List<Vector3>();
			path2Cached.Add(new Vector3(-5F, 0F, 5F));
			path2Cached.Add(new Vector3(-4F, 0F, 4F));
			path2Cached.Add(new Vector3(-3F, 0F, 5F));
			path2Cached.Add(new Vector3(-2F, 0F, 4F));
			path2Cached.Add(new Vector3(-1F, 0F, 5F));
			path2Cached.Add(new Vector3(0F, 0F, 4F));
			path2Cached.Add(new Vector3(1F, 0F, 5F));
			path2Cached.Add(new Vector3(2F, 0F, 4F));
			path2Cached.Add(new Vector3(3F, 0F, 5F));
			path2Cached.Add(new Vector3(4F, 0F, 4F));
		}
		return path2Cached;
	}

	public static List<Vector3> path3(){
		if(path3Cached == null) {
			path3Cached = new List<Vector3>();
			path3Cached.Add(new Vector3(-2.5F, 0F, 2.5F));
			path3Cached.Add(new Vector3(0F, 0F, 0F));
			path3Cached.Add(new Vector3(2.5F, 0F, 2.5F));
			path3Cached.Add(new Vector3(0F, 0F, 0F));
			path3Cached.Add(new Vector3(2.5F, 0F, -2.5F));
			path3Cached.Add(new Vector3(0F, 0F, 0F));
			path3Cached.Add(new Vector3(-2.5F, 0F, -2.5F));
			path3Cached.Add(new Vector3(0F, 0F, 0F));
		}
		return path3Cached;
	}
}
