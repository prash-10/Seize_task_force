using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseWay : MonoBehaviour {

	public Transform player;
	Animator anim;
	public Transform gun;
	public GameObject chest;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.8f;
	public float speed = 1.5f;
	float accuracyWP = 5.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	IEnumerator FireDelay()
	{
		yield return new WaitForSeconds (2f);
		gameObject.GetComponent<ShotEnemy> ().fire ();
	}
		
	// Update is called once per frame
	void Update () {

		//if (Health.isPlayerActive) {
			Vector3 direction = player.position - this.transform.position;
			float angle = Vector3.Angle (direction, this.transform.forward);
		Vector3 angle2 = player.position - gun.transform.position;

		if (state == "patrol" && (waypoints.Length>0))
			{
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", true);
				if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
				{
					currentWP++;
					if(currentWP>= waypoints.Length)
					{
						currentWP = 0;
					}
				}

				direction = waypoints [currentWP].transform.position - transform.position;
				this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
				this.transform.Translate(0,0,Time.deltaTime *speed);
			}

			if (Vector3.Distance (player.position, this.transform.position) < 50 && (angle < 30 || state == "pursuing")) {
				//Vector3 direction = player.position - this.transform.position;
				direction.y = 0;

				state = "pursuing";

				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			Vector3 v = chest.transform.position;
			//gun.transform.rotation.SetLookRotation(new Vector3(0,v.y,0));
				//anim.SetBool ("isIdle", true);
				anim.SetBool ("isWalking", false);

				if (direction.magnitude < 30) {
					this.transform.Translate (0, 0, 0.05f);
					anim.SetBool ("isWalking", true);
					anim.SetBool ("isDead", false);
				}

				 if (direction.magnitude < 20 )
				{
				
				attack ();
				}
			}

			else {
				//anim.SetBool ("isIdle", true);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isDead", false);
				state = "patrol";
			}
		//}
	}

	void attack()
	{
		RaycastHit hit;
		if (Physics.Raycast (gun.transform.position, transform.forward, out hit)) {
			//Debug.Log (hit.collider.transform.root.name);
			if (hit.collider.transform.root.name == "Swat") {
				//gameObject.GetComponent<ShotEnemy> ().fire ();
				StartCoroutine("FireDelay");
			}
		}
	}
}
