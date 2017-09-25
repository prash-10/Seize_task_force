using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot :MonoBehaviour  {
	int x=0;
	Vector3 v=new Vector3(-90,0,0);
	Quaternion q = new Quaternion (0,-90,90,0);
	//public Transform dir;
	[SerializeField] private AudioSource soundsource;
	[SerializeField] private GameObject explosion;
	private int damage_head=100,damage_chest=25,damage_hand=10,damage_leg=10,damage_foot=5,damage;
	private float range = 200;
	[SerializeField] private Transform gunTransform;
	private RaycastHit hit;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void fire(){
		if(Physics.Raycast(gunTransform.transform.TransformPoint(0f,0f,0.5f),gunTransform.forward,out hit,range))
		{
			Debug.Log (hit.collider.tag);
			//Debug.Log (hit.transform.root.name);
			if (hit.collider.tag == "head") {
				
				damage = damage_head;
				//hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
				hit.collider.transform.root.gameObject.GetComponent<enemyhealth> ().DeductHealth (damage);
			}else if (hit.collider.tag == "leg") {
				damage = damage_leg;
				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}else if (hit.collider.tag == "hand") {
				
				damage = damage_hand;
				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}else if (hit.collider.tag == "chest") {
//				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
				damage = damage_chest;
				hit.collider.transform.root.gameObject.GetComponent<enemyhealth> ().DeductHealth (damage);
				//hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}else if (hit.collider.tag == "foot") {
//				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
				damage = damage_foot;
				hit.collider.gameObject.GetComponent<Health> ().DeductHealth (damage);
			}

			if (hit.transform.tag == "Player") {
				string uidentity = hit.transform.root.name;
			
			}

		}
		soundsource.Play ();

	}
}
