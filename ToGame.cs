using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour {
	public GameObject a;

	public void LoadScene()
	{
		if (a.tag == "toGame") {
			SceneManager.LoadScene ("menu_anim");
		}
	}
}
