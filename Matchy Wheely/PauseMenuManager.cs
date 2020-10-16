using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

	public GameObject menu;
	public Text currentScoreText;

	void Awake(){
		Time.timeScale = 0f;
	}

	void Start(){
		currentScoreText.text = "Score: " + GameplayController.instance.GameScore.ToString ();
	}

	public void ResumeGame(){
		menu.GetComponent<Animator> ().Play ("PauseMenuPanelSlideOut");

		StartCoroutine(UnloadSceneWait ());
	}

	IEnumerator UnloadSceneWait(){
		yield return new WaitForSecondsRealtime (2.2f);

		SceneManager.UnloadSceneAsync ("Pause Menu");

		Time.timeScale = 1f;
	}
}
