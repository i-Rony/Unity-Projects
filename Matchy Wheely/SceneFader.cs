using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	public static SceneFader instance;

	void Awake () {
		MakeSingleton ();
	}
	

	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void FadeIn(){
		GetComponentInChildren<Animator> ().Play ("FadeInAnimation");
	}

	public void FadeInGameplay(){
		Time.timeScale = 1f;
		GetComponentInChildren<Animator> ().Play ("FadeOutAnimation");
		StartCoroutine (FadeOutFadeInAnim ("Gameplay"));
	}

	public void FadeInMainMenu(){
		Time.timeScale = 1f;
		GetComponentInChildren<Animator> ().Play ("FadeOutAnimation");
		StartCoroutine (FadeOutFadeInAnim ("Main Menu"));
	}

	IEnumerator FadeOutFadeInAnim(string levelName){
		yield return new WaitForSeconds (1.5f);
		FadeIn ();

		SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().name);
		SceneManager.LoadScene (levelName);

	}
}
