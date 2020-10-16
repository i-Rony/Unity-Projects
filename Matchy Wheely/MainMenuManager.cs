using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Button soundButton;
	public Sprite[] soundButtonImages;


	void Start(){
		if (GameManager.instance.MusicPreference == 0) {
			soundButton.GetComponent<Image> ().sprite = soundButtonImages [1];
		} else {
			soundButton.GetComponent<Image> ().sprite = soundButtonImages [0];
		}
	}

	public void GoToGame(){
		SceneFader.instance.FadeInGameplay ();
	}

	public void ChangeMusicPreference(){
		if (GameManager.instance.MusicPreference == 0) {
			GameManager.instance.MusicPreference = 1;
			soundButton.GetComponent<Image> ().sprite = soundButtonImages [0];
		} else {
			GameManager.instance.MusicPreference = 0;
			soundButton.GetComponent<Image> ().sprite = soundButtonImages [1];
			SoundManager.instance.TurnMusicBackOn ();
		}


	}
}
