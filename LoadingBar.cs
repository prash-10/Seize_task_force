using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour {

	AsyncOperation ao;
	public GameObject loadingScreen;
	public Slider progBar;
	int x;
	public Text loadingText;

	public bool isFakeLoadingBar = false;
	//public float FakeIncrement = 0f;
	//public float fakeTiming = 0f;

	// Use this for initialization
	void Awake(){
		x = 0;
		Debug.Log ("x set to 0 awake");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene ("DemoScene");
		/*loadingScreen.SetActive (true);
		progBar.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text = "Loading...";

		if (!isFakeLoadingBar) {
			StartCoroutine (LoadLevelWithRealProgress());
		}*/
	}

	IEnumerator LoadLevelWithRealProgress()
	{
		yield return new WaitForSeconds (2); //time to wait

		ao = SceneManager.LoadSceneAsync (2); //name of scene to load
		ao.allowSceneActivation = false;

		while (!ao.isDone) {
			progBar.value = ao.progress;
			if (x == 0) {
			if (ao.progress == .9f) {
				progBar.value = 1f;
				loadingText.text = "Tap to continue";

					if (Input.GetKeyDown ("b") || Input.touchCount > 0) {
						x = 1;
						Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"+x);
						ao.allowSceneActivation = true;
						x = 1;
						Debug.Log ("loaded");
						progBar.gameObject.SetActive (false);
						//loadingText.gameObject.SetActive (false);
					}
				}
			}

			Debug.Log (ao.progress);
			yield return null;
		}
	}
}
