using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {

	//public GameObject a;
	public void exit(){
		Application.Quit ();
	}

	public void LoadScene()
	{
		
			SceneManager.LoadScene ("main_menu");

}
}
