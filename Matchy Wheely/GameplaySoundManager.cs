using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySoundManager : MonoBehaviour {

	public static GameplaySoundManager instance;


	void Awake(){
		MakeInstance ();
	}

	void MakeInstance(){
		if (instance == null)
			instance = this;
	}

	public void PlayScoreSound(){
		if (GameManager.instance.MusicPreference == 0) {
			GetComponent<AudioSource> ().Play ();
		}
	}
}
