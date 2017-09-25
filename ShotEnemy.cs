using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy :MonoBehaviour  {
	int x=0;
	Vector3 v=new Vector3(-90,0,0);
	Quaternion q = new Quaternion (0,-90,90,0);
	//public Transform dir;
	[SerializeField] private AudioSource soundsource;
	[SerializeField] private GameObject explosion;
	private int damage_head=100,damage_chest=2,damage_hand=10,damage_leg=10,damage_foot=5,damage;
	private float range = 200;
	[SerializeField] private Transform gunTransform;
	private RaycastHit hit;
	void Start () {
		//InvokeRepeating ("fire",1.3f,1.3f);
	}

	// Update is called once per frame
	void Update () {
		//fire ();
	}

	public void fire(){
		if(Physics.Raycast(gunTransform.transform.TransformPoint(0f,0f,0.5f),gunTransform.forward,out hit,range))
		{
			Debug.Log ("11111");
			Debug.Log (hit.collider.transform.root.name);
			if (hit.collider.tag == "head") {

				damage = damage_head;
				//Debug.Log ("hit head");
				//Debug.Log (hit.collider.gameObject.name);
				hit.collider.transform.root.gameObject.GetComponent<Health> ().DeductHealth (damage);
			//	hit.collider.transform.root.gameObject.GetComponent<enemyhealth> ().DeductHealth (damage);

			}else if (hit.collider.tag == "leg") {
				damage = damage_leg;
				Debug.Log (hit.collider.transform.root.gameObject.name);
				hit.collider.transform.root.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}else if (hit.collider.tag == "hand") {
				//Debug.Log (hit.collider.gameObject.name);
				damage = damage_hand;
				hit.collider.transform.root.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}else if (hit.collider.tag == "chest") {
				//Debug.Log (hit.collider.gameObject.name);
				Debug.Log ("hit chest");
				hit.collider.transform.root.gameObject.GetComponent<Health> ().DeductHealth (damage);
				//				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
				damage = damage_chest;
				hit.collider.transform.root.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}else if (hit.collider.tag == "foot") {
				//				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
				damage = damage_foot;
				hit.collider.transform.root.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}

			if (hit.transform.tag == "Player") {
				string uidentity = hit.transform.root.name;
			}

		}
		soundsource.Play ();

	}
}