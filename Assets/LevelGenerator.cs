using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	private EnemyGenerator enemyGenerator;

	private PlayerScript player;
	private int lives = 5;

	private int level = 0;

	// Use this for initialization
	void Start () {
		enemyGenerator = (EnemyGenerator)FindObjectOfType(typeof(EnemyGenerator));
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) {
			lives--;
			if(this.lives == 0) {
				gameOver();
			} else {
				Vector4 boundary = new Vector4(-5, 5, 5, -5);
				player = PlayerScript.Create(boundary, transform);
			}
			Debug.Log("Lives left : " + this.lives);
		}


		if(enemyGenerator.levelClear) {
			startNewLevel();
			Debug.Log("Reached a new level :" + this.level);
		}
	}

	public void startNewLevel() {
		this.level++;
		enemyGenerator.spawnEnemies(0);
	}

	public void gameOver() {

	}
}
