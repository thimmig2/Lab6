using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public static int enemiesKilled;


	private EnemyGenerator enemyGenerator;
	private PlayerScript player;
	private int lives = 5;
	private int level = 0;
	private bool gameOver = true;

	// Use this for initialization
	void Start () {
		enemyGenerator = (EnemyGenerator)FindObjectOfType(typeof(EnemyGenerator));
		Debug.Log("Controls for the player are :");
		Debug.Log("\tarrow keys for flight control");
		Debug.Log("\tz : one time board clearing bomb");
		Debug.Log("\tx : strafe shot (takes more energy to fire)");
		Debug.Log("\tc : normal shot");
		Debug.Log("Press Home to start a new game!");
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver == false && player == null) {
			lives--;
			if(this.lives == 0) {
				gameOver();
			} else {
				Vector4 boundary = new Vector4(-5, 5, 5, -5);
				player = PlayerScript.Create(boundary, transform);
			}
			Debug.Log("You died! Lives left : " + this.lives);
		}


		if(gameOver == false && enemyGenerator.levelClear) {
			startNewLevel();
		}

		if(Input.GetKeyUp(KeyCode.Home)) {
			startNewGame();
		}
	}

	public void startNewGame() {
		enemyGenerator.clearEnemies();
		enemiesKilled = 0;
		this.level = 0;
		this.lives = 5;
		this.gameOver = false;
		Debug.Log("Started New Game");
	}

	public void startNewLevel() {
		if(level == 10) {
			gameWon();
			this.gameOver = true;
		} else {
			this.level++;
			enemyGenerator.spawnEnemies(level);
			Debug.Log("Beggining Level :" + this.level);
		}
	}

	public void gameOver() {
		enemyGenerator.clearEnemies();
		Debug.Log("You ran out of lives after killing " + enemiesKilled + " enemy ships, sorry :/!");
	}

	public void gameWon() {
		enemyGenerator.clearEnemies();
		Debug.Log("You Won after killing " + enemiesKilled + " enemy ships!!!");
	}
}
