using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	//	[SyncVar] private int heal=100;
	private int health=100;
	//public GameObject obj;
	 static Animator anim;
	[SerializeField]private Text htext;
	// Use this for initialization
	void Start () {
		//Debug.Log ("health running");

		//htext = GameObject.Find ("Text_t").GetComponent<Text>();
		SetHealthText ();
		//htext.text = "Health "+health.ToString ();
		anim = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {
		Debug.Log (health);
		if (health <= 0) {
			anim.SetFloat ("dead", 1f);
		}

	}
	void SetHealthText()
	{
		
			htext.text = "Health" + health.ToString ();

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
