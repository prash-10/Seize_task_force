using UnityEngine;
using System.Collections;
public class contoller : MonoBehaviour {
	static Animator anim;
	int active=1,deactive=0,x=0,t=0,SPEED=2,TSPEED=20;
	public headstick cont;
	public GameObject camera;
	//public Look look;
	// klo;
	Vector3 sta;
	Vector3 cro;
	float run=0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		sta = new Vector3 (.63f, 0.37819f, -1.35f);
			cro = new Vector3 (0.00077249f, 0.17819f ,-0.78800f);
		camera.transform.localPosition = sta;
	}
	
	// Update is called once per frame
	void Update () {
	//	klo = look.Horizontal();


		float turn=0;
		float transition = cont.Vertical() * SPEED * Time.deltaTime;
		float rotation = cont.Horizontal()*Time.deltaTime * SPEED;

		if (run>0) {
			TSPEED = 40;
			SPEED = 6;
				anim.SetInteger ("isRunning", active); 

		} else 
		{
			TSPEED = 20;
			SPEED = 2; 
			anim.SetInteger ("isRunning", deactive);
		}
		/*
		if (cont.Horizontal()<0)
		{
			
			t = -1;
			turn = t * Time.deltaTime * TSPEED;
			transform.Rotate(0,turn,0);
			//anim.SetInteger ("turnRT", deactive);
		//	anim.SetInteger ("turnLT", active);

		}else if (cont.Horizontal()>0)
		{
			t = 1;
			turn = t * Time.deltaTime * TSPEED;
			transform.Rotate(0,turn,0);
		//	anim.SetInteger ("turnRT", active);
		//	anim.SetInteger ("turnLT", deactive);
		}else
		{

			anim.SetInteger ("turnRT", deactive);
			anim.SetInteger ("turnLT", deactive);
			t = 0;
			turn = t * Time.deltaTime * 15;
			transform.Rotate(0,turn,0);

		}*/


		transform.Translate (rotation, 0, transition);
		//transform.Rotate (0, rotation, 0);

		if(transition > 0f)
		{
			
			anim.SetInteger("isWalkingFD",active);
		}
		else
		{
			anim.SetInteger("isWalkingFD",deactive);
		}
		if(transition < 0f)
		{

			anim.SetInteger("isWalkingBK",1);
		}
		else
		{
			anim.SetInteger("isWalkingBK",0);
		}
		if(rotation > 0f)
		{

			anim.SetInteger("isWalkingRT",1);
		}
		else
		{
			anim.SetInteger("isWalkingRT",0);
		}
		if(rotation < 0f)
		{

			anim.SetInteger("isWalkingLT",1);
		}
		else
		{
			anim.SetInteger("isWalkingLT",0);
		}

	
	}
	public void Running()
	{if (run == 1) {
			run= 0;
	} else {run = 1;
		}
		
	}
	public void Crouch()
	{
			if (x == 0) {
				x = 1;
			camera.transform.localPosition = cro;
				anim.SetInteger ("crouch", active);
			} else {
				x = 0;
			camera.transform.localPosition = sta;

				anim.SetInteger ("crouch", 0);
			}
		
	}

}
