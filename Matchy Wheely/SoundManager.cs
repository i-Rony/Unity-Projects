using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	bool canBGMusicPlay = true;

	void Awake(){
		MakeSingleton ();
	}

	void Start(){
		if (GameManager.instance.MusicPreference == 0 && canBGMusicPlay == true) {
			GetComponent<AudioSource> ().Play ();
			StartCoroutine (BGMusicWait ());
		}
	}

	void MakeSingleton(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Update(){
		if (GameManager.instance.MusicPreference == 1) {
			GetComponent<AudioSource> ().Stop ();
		}
	}

	IEnumerator BGMusicWait(){
		canBGMusicPlay = false;
		yield return new WaitForSeconds (GetComponent<AudioSource> ().clip.length);
		canBGMusicPlay = true;
	}

	public void TurnMusicBackOn(){
		GetComponent<AudioSource> ().Play ();
		StartCoroutine (BGMusicWait ());
	}
}
