using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickManager : MonoBehaviour {

	Button thisButton;

	void Awake(){
		thisButton = GetComponent<Button> ();
		thisButton.onClick.AddListener (() => PlayClickSound ());
	}

	void PlayClickSound(){
		if (GameManager.instance.MusicPreference == 0) {
			this.GetComponent<AudioSource> ().Play ();
		}
	}
}
