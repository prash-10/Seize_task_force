using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToInstruction : MonoBehaviour {
	public GameObject b;

	public void LoadScene()
	{
		if (b.tag == "toInst") {
			SceneManager.LoadScene ("instructions");
		}
	}
}
