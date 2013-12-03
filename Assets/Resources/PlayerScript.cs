using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private static float defaultHealth = 100;
	private static float defaultShield = 10;
	private static float defaultPower = 10;
	private static float defaultRegen = 5F;

	private float health = defaultHealth;
	private float shield = defaultShield;
	private float power = 0;
	private float maxPower = defaultPower;
	private float regen = defaultRegen;

	private Vector4 boundaries;

	private static float maxAccel = 2;
	private static float maxVeloc = 10;

	private Vector3 veloc = Vector3.zero;

	private bool usedBomb = false;

	public static PlayerScript Create(Vector4 boundaries, Transform parent){
		GameObject player = Instantiate(Resources.Load("Player", typeof(GameObject))) as GameObject;
		player.transform.parent = parent;
		PlayerScript playerScript = player.GetComponent<PlayerScript>();
		playerScript.boundaries = boundaries;

		return playerScript;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.power = Mathf.Min(this.power + (Time.deltaTime * this.regen), this.maxPower);
		controls();
	}

	public void controls() {
		 
		if (Input.GetKey(KeyCode.LeftArrow) && transform.localPosition.x > boundaries.x) {
			veloc.x -= maxAccel * Time.deltaTime;
			veloc.x = Mathf.Max(maxVeloc, veloc.x);
		} else if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x < boundaries.z) {
			veloc.x += maxAccel * Time.deltaTime;
			veloc.x = Mathf.Min(maxVeloc, veloc.x);
		} else {
			veloc.x *= .95;
		}

		if (Input.GetKey(KeyCode.UpArrow) && transform.localPosition.z < boundaries.y) {
			veloc.z += maxAccel * Time.deltaTime;
			veloc.z = Mathf.Min(maxVeloc, veloc.z);
		} else if (Input.GetKey(KeyCode.DownArrow) && transform.localPosition.z > boundaries.w) {
			veloc.z -= maxAccel * Time.deltaTime;
			veloc.z = Mathf.Max(maxVeloc, veloc.z);
		} else {
			veloc.x *= .95;
		}

		if (Input.GetKey(KeyCode.Z) && usedBomb == false) {
			usedBomb = true;
			foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
				enemy.SendMessage("die");
			}
		}

		if (Input.GetKey(KeyCode.X)) {
			if(this.power > 5){
				BulletScript.Create(true, 2, transform);				
				this.power -= 5;
			}
		}

		if (Input.GetKey(KeyCode.C)) {
			if(this.power > 1){
				BulletScript.Create(true, 1, transform);
				this.power -= 1;
			}
		}

		updatePosition();
	}

	public void updatePosition() {
		transform.position += veloc * Time.deltaTime;
	}

	public void applyDamage(float damage) {
		health -= damage;
		Debug.Log("You've been hit, current health :" + health);
		if(health <= 0) {
			Destroy(gameObject);
		}
	}

	public void upgradeRegen() {
		this.regen *= 2;
	}

	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.SendMessage("applyDamage", 1000);
            this.applyDamage(100);
        }
    }

}
