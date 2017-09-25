
//using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;

public class player_script : NetworkBehaviour {
	Transform mytransform;
	Vector3 playerPosition;
	[SyncVar] public Quaternion playerRotation;
	 float turnYRotation;
	[SerializeField] private Camera cam;
	[SerializeField] private Canvas canvas;
	[SerializeField] private Aim aim;
	[SerializeField] private headstick hs;
	public float positionUpdateRate=0.2f;
	public float smooth=4;// Use this for initialization
	
	void Start () {
		mytransform = transform;
		gameObject.name = netId.ToString ();
		if (isLocalPlayer) {
			//GameObject.Find("Main Camera").SetActive(false);
			cam.enabled=true;
			canvas.enabled = true;
			//a=GetComponent<Animator> ();
			//a.enabled = true;;
			//	na=GetComponent<NetworkAnimator> ();
			//	na.enabled = tru
			//	na.animator=a;
			GetComponent<contoller> ().enabled = true;
			GetComponent<rotate> ().enabled = true;
			aim.enabled = true;
			hs.enabled = true;
			//	transform.Find ("Swat1").gameObject.SetActive (true);
			StartCoroutine(UpdatePosition());
		}
	}
	void Update()
	{
		LerpPosition ();
	}
	
	void LerpPosition()
	{
		if (isLocalPlayer) {
			return;
		}
		//Debug.Log (gameObject.name + " current position of other for lerp" + mytransform.position);
	//	Debug.Log (gameObject.name + " recieved position of other for lerp" + playerPosition);

		mytransform.position = Vector3.Lerp (mytransform.position, playerPosition, Time.deltaTime * smooth);
		//mytransform.eulerAngles = new Vector3(0,Mathf.Lerp(mytransform.eulerAngles.y,turnYRotation,Time.deltaTime*smooth),0);
		 //= new Vector3 (0,Mathf.Lerp (mytransform.rotation.y, playerRotation.y, Time.deltaTime * smooth),0);	
		//Debug.Log (gameObject.name + " current rotation of other for lerp" + mytransform.rotation);
		//Debug.Log (gameObject.name + "recieved rotation of other for lerp" + playerRotation);
		//mytransform.rotation = Quaternion.Slerp (mytransform.rotation, playerRotation, Time.deltaTime * smooth);
	}
	
	IEnumerator UpdatePosition(){
		while (true) {
			CmdSendPosition(mytransform.position);
			 
		//	CmdSendRotation(mytransform.rotation.eulerAngles.y);
		//	CmdSendRotation(mytransform.rotation);
			//Debug.Log ("sednt");
			//Debug.Log(mytransform.rotation.eulerAngles);
			yield return new WaitForSeconds(positionUpdateRate);
		}
	}
	[Command]
	void CmdSendPosition(Vector3 position)
	{
		playerPosition=position;

		//Debug.Log (" in cmd position sent by "+gameObject.name+" to server "+position);
		RpcRecievePosition (position);
	}
	void CmdSendRotation(Quaternion r)
	{
		playerRotation = r;
		//Debug.Log (" in cmd rotation sent by "+gameObject.name+" to server "+r);
		RpcRecieveRotation (r);
	}
	[ClientRpc]
	void RpcRecievePosition(Vector3 position){
		playerPosition=position; 
		//Debug.Log ("in rpc position recieved" + position);
		//Debug.Log (" in rpc position recieved by "+gameObject.name+" from server "+position);
	}
	// Update is called once per frame
	void RpcRecieveRotation(Quaternion r){
		playerRotation = r; 
		//Debug.Log (" in rpc rotation recieved by"+gameObject.name+" from server "+playerRotation);
		
	}
}
