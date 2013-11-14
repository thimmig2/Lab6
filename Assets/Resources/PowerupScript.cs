using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	private int age;

	// Use this for initialization
	void Start () {
		age = 500;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(UnityEngine.Random.Range(-.05F, .05F), 0, UnityEngine.Random.Range(-.05F, .05F));
		age--;
		if(age == 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
        //if(collision.gameObject.tag == "Predator" || collision.gameObject.tag == "Goal") {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.SendMessage("upgradeRegen");
            Destroy(gameObject);
        }
    }
}
