using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private static float defaultHealth = 100;
	private static float defaultShield = 10;
	private static float defaultSpeed = 10;
	private static float defaultPower = 10;
	private static float defaultRegen = 5F;

	private float health = defaultHealth;
	private float shield = defaultShield;
	private float speed = defaultSpeed;
	private float power = 0;
	private float maxPower = defaultPower;
	private float regen = defaultRegen;

	private Vector4 boundaries;

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
			transform.position += Vector3.left * speed * Time.deltaTime;
		} 

		if (Input.GetKey(KeyCode.UpArrow) && transform.localPosition.z < boundaries.y) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x < boundaries.z) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 

		if (Input.GetKey(KeyCode.DownArrow) && transform.localPosition.z > boundaries.w) {
			transform.position += Vector3.back * speed * Time.deltaTime;
		} 

		if (Input.GetKey(KeyCode.Z)) {
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

	}

	public void applyDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
        //if(collision.gameObject.tag == "Predator" || collision.gameObject.tag == "Goal") {
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.SendMessage("applyDamage", 1000);
            this.applyDamage(100);
        }
    }

}
