using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTest : MonoBehaviour {
	public GameObject c;

	public void LoadScene()
	{
		if (c.tag == "toTest") {
			SceneManager.LoadScene ("testing");
		}
	}
}
