using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	private EnemyGenerator enemyGenerator;

	public PlayerScript player;

	// Use this for initialization
	void Start () {
		enemyGenerator = (EnemyGenerator)FindObjectOfType(typeof(EnemyGenerator));
		enemyGenerator.spawnEnemies(0);

		float[] boundary = new float[4];
		boundary[0] = -5F;
		boundary[1] = 5F;
		boundary[2] = 5F;
		boundary[3] = -5F;
		player = PlayerScript.Create(boundary, transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
