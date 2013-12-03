using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	protected float damage;
	protected float speed;
	protected bool friendly;
	private static GameObject bulletPrefab = Resources.Load("Bullet", typeof(GameObject)) as GameObject;

	public static void Create(bool friendly, int bulletType, Transform parent){
		
		if(bulletType == 1) {
				GameObject bullet = Instantiate(bulletPrefab, parent.position, parent.rotation) as GameObject;
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
				bulletScript.damage = 2;
				bulletScript.speed = 10;
				bulletScript.friendly = friendly;
		} else if(bulletType == 2) {
			for(float angle = -45F; angle <= 45; angle += 15) {
				Quaternion target = Quaternion.Euler(0, angle, 0);
				GameObject bullet = Instantiate(bulletPrefab, parent.position, target) as GameObject;
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
				bulletScript.damage = 10;
				bulletScript.speed = 15;
				bulletScript.friendly = friendly;
			}
		} else if(bulletType == 3) {
			// find the player and orient the bullet to it
			GameObject player = GameObject.Find("Player");
			var angle = Vector3.Angle(player.transform, parent.forward);
			Quaternion rotation = transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
			
			GameObject bullet = Instantiate(bulletPrefab, parent.position, rotation) as GameObject;
			BulletScript bulletScript = bullet.GetComponent<BulletScript>();
			bulletScript.damage = 5;
			bulletScript.speed = 10;
			bulletScript.friendly = friendly;

		} else if(bulletType == 4) {
			for(float angle = 135F; angle <= 225; angle += 15) {
				Quaternion target = Quaternion.Euler(0, angle, 0);
				GameObject bullet = Instantiate(bulletPrefab, parent.position, target) as GameObject;
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
				bulletScript.damage = 10;
				bulletScript.speed = 15;
				bulletScript.friendly = friendly;
			}
		}
	}

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
        if(collision.gameObject.tag == "Bullet") {
			Destroy(collision.gameObject);
        } else if(collision.gameObject.tag == "Player" && this.friendly == false) {
			collision.gameObject.SendMessage("applyDamage", this.damage);
		} else if(collision.gameObject.tag == "Enemy" && this.friendly == true) {
			collision.gameObject.SendMessage("applyDamage", this.damage);     	
		}	

        Destroy(gameObject);
    }
}
