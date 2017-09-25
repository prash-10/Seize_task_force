using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour{
	public Transform canvas;
	public Transform Player;
	public GameObject a;

	void Update()
	{

	}

	public void Pause()
	{
		

			if (canvas.gameObject.activeInHierarchy == false)
			{
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			else
			{
				canvas.gameObject.SetActive(false);
				Time.timeScale = 1;
			}

	}

	public void LoadScene ()
	{
		if (a.tag == "exit") {
			SceneManager.LoadScene ("main_menu");
		}
	}
}