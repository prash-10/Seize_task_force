using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour {
	int t=0;
	float turn=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("i"))
		{
			t = -1;
			turn = t * Time.deltaTime * 10;
			transform.Rotate(turn,0,0);

		}else if (Input.GetKey ("k"))
		{
			t = 1;
			turn = t * Time.deltaTime * 10;
			transform.Rotate(turn,0,0);
		}else
		{


			t = 0;
			turn = t * Time.deltaTime * 15;
			transform.Rotate(turn,0,0);

		}

		
	}
}
