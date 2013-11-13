using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float health = 100;
	public float speed = 10;

	public static float gunPowerMax = 10;
	public float gunPower = 0;
	public float gunPowerRegenRate = 1F;
	public float[] boundaries;

	public static PlayerScript Create(float[] boundaries, Transform parent){
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
		Debug.Log(gunPower);
		gunPower = Mathf.Min(gunPower + (gunPowerRegenRate * Time.deltaTime * 20), gunPowerMax);
		controls();
	}



	public void controls() {
		 
		if (Input.GetKey(KeyCode.LeftArrow) && transform.localPosition.x > boundaries[0]) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} 

		if (Input.GetKey(KeyCode.UpArrow) && transform.localPosition.z < boundaries[1]) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x < boundaries[2]) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 

		if (Input.GetKey(KeyCode.DownArrow) && transform.localPosition.z > boundaries[3]) {
			transform.position += Vector3.back * speed * Time.deltaTime;
		} 

		if (Input.GetKey(KeyCode.Z)) {
			// bomb
		}

		if (Input.GetKey(KeyCode.X)) {
			if(gunPower > 5){
				for(float angle = -45F; angle <= 45; angle += 15) {
					Quaternion target = Quaternion.Euler(0, angle, 0);
					GameObject player = Instantiate(Resources.Load("Bullet", typeof(GameObject)), transform.position, target) as GameObject;
				
				}

				gunPower -= 5;
			}
		}

		if (Input.GetKey(KeyCode.C)) {
			if(gunPower > 1){
				GameObject player = Instantiate(Resources.Load("Bullet", typeof(GameObject)), transform.position, transform.rotation) as GameObject;
				gunPower -= 1;
			}
		}

	}

	public void applyDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Destroy(gameObject);
		}
	}

}
