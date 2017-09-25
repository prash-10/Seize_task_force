using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealth : MonoBehaviour {
	//	[SyncVar] private int heal=100;
	public int health=100;
	//public GameObject obj;
	Animator anim;
//	[SerializeField]private Text htext;
	// Use this for initialization
	void Start () {
		//Debug.Log ("health running");

		//htext = GameObject.Find ("Text_t").GetComponent<Text>();
		SetHealthText ();
		//htext.text = "Health "+health.ToString ();
		anim = GetComponent<Animator>();

	}

	IEnumerator Halt ()
	{
		yield return new WaitForSeconds (2.5f);
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (health);
		if (health <= 0) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isDead", true);

			StartCoroutine ("Halt");
		}

	}
	void SetHealthText()
	{

//		htext.text = "Health" + health.ToString ();

	}
	public void DeductHealth(int dmg)
	{
		health -= dmg;
	}
	void OnHealthChanged(int h)
	{
		health = h;
		SetHealthText();
	}

}
