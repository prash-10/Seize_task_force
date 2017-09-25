using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_move : MonoBehaviour {
	public Look look;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("ffffffffffffffffffffffffff"+transform.rotation.z);
		
		if (look.Vertical () >0 && look.Horizontal()==0 && transform.rotation.z<0.12 && transform.rotation.z>-0.27) 
		{
			transform.Rotate (1f, 0, 0);
		}
		if (look.Vertical ()<0 && transform.rotation.z>-0.24 && look.Horizontal()==0) 
		{
			transform.Rotate (-1f, 0, 0);
		
		}
	}
}
