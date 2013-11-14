using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	private int age;
	private float speed;
	protected GameObject parent;
	private static GameObject explosionPrefab = Resources.Load("ExplosionFragment", typeof(GameObject)) as GameObject;

	public static void Create(GameObject parent){
		GameObject fragment = Instantiate(explosionPrefab, parent.transform.position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0)) as GameObject;
		fragment.transform.localScale *= UnityEngine.Random.Range(.5F, 1.5F);
		ExplosionScript explosionScript = fragment.GetComponent<ExplosionScript>();
		explosionScript.parent = parent;
	}

	void Start() { 	
		this.age = UnityEngine.Random.Range(55, 150);
		this.speed = UnityEngine.Random.Range(4, 25);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.TransformDirection(Vector3.forward) * this.speed * Time.deltaTime;

		age--;

		//this.renderer.material.color = new Color(0, 0, 0, .75F);

		if(age==0) {
			Destroy(this.parent);
			Destroy(gameObject);
		}
	}
}
