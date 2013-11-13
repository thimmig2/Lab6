using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	private float bulletDamage = 2F;
	private float speed = 10;

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
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet"){
            collision.gameObject.SendMessage("applyDamage", this.bulletDamage);
            Debug.Log(this.bulletDamage);
            Destroy(gameObject);
        }
    }
}
