using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float bulletDamage = 2;
	public float speed = 10;
	public bool done = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;

		if(renderer.isVisible == false) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
        //if(collision.gameObject.tag == "Predator" || collision.gameObject.tag == "Goal") {
        if(done == false && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet"){
            done = true;
            collision.gameObject.SendMessage("applyDamage", bulletDamage);
            Destroy(gameObject);
            Debug.Log("Collision");
        }
    }
}
