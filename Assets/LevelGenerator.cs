using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	private EnemyGenerator enemyGenerator;

	public PlayerScript player;

	// Use this for initialization
	void Start () {
		enemyGenerator = (EnemyGenerator)FindObjectOfType(typeof(EnemyGenerator));
		enemyGenerator.spawnEnemies(0);

		Vector4 boundary = new Vector4(-5, 5, 5, -5);
		player = PlayerScript.Create(boundary, transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
