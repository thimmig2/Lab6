using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	private int age;
	private int type;
	private float speed;

	public static void Create(Transform parent) {
		GameObject powerup = Instantiate(Resources.Load("Powerup", typeof(GameObject)), parent.position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0)) as GameObject;
	}

	public void setType() {
		// will generate 0 - 4
		this.type = (int)UnityEngine.Random.Range(0, 4.99F);
		Debug.Log(this.type);
		switch(this.type) {
			case 0:
				renderer.material.color = Color.blue;
				break;
			case 1:
				renderer.material.color = Color.cyan;
				break;
			case 2:
				renderer.material.color = Color.magenta;
				break;
			case 3:
				renderer.material.color = Color.yellow;
				break;
			case 4:
				renderer.material.color = Color.green;
				break;
		}
	}

	// Use this for initialization
	void Start () {
		this.setType();
		this.age = 500;
		this.speed = UnityEngine.Random.Range(0, 3);
	}
	
	// Update is called once per frame
	void Update () {
		age--;
		if(age == 0) {
			Destroy(gameObject);
		}

		transform.position += transform.TransformDirection(Vector3.forward) * this.speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision) {
        //if(collision.gameObject.tag == "Predator" || collision.gameObject.tag == "Goal") {
        if(collision.gameObject.tag == "Player"){
        	string upgrade = "";

        	switch(this.type) {
				case 0:
					upgrade = "upgradeRegen";
					break;
				case 1:
					//
					break;
				case 2:
					//
					break;
				case 3:
					//
					break;
				case 4:
					//
					break;
			}

            collision.gameObject.SendMessage(upgrade);
            Destroy(gameObject);
        }
    }
}
