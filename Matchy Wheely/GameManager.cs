using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int HighScore { get { return PlayerPrefs.GetInt ("High Score");} set{ PlayerPrefs.SetInt ("High Score", value); } }
	public int MusicPreference { get{ return PlayerPrefs.GetInt ("Music Preference"); } set{ PlayerPrefs.SetInt ("Music Preference", value);} }
	public int GameOverAdCount { get{ return PlayerPrefs.GetInt ("GameOverAdCount"); } set{ PlayerPrefs.SetInt ("GameOverAdCount", value); } }
	public int MainMenuAdCount { get{ return PlayerPrefs.GetInt ("MainMenuAdCount"); } set{ PlayerPrefs.SetInt ("MainMenuAdCount", value); } }

	void Awake(){
		MakeSingleton ();
	}

	void MakeSingleton(){
		if (instance != null) {
			Destroy (gameObject);

		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}


	void Start(){
		if(!PlayerPrefs.HasKey("HasPlayedGame")){
			PlayerPrefs.SetInt ("HasPlayedGame", 1);
			PlayerPrefs.SetInt ("High Score", 0);
			PlayerPrefs.SetInt ("Music Preference", 0);
			PlayerPrefs.SetInt ("GameOverAdCount", 0);
			PlayerPrefs.SetInt ("MainMenuAdCount", 0);

		}


		if (SceneManager.GetActiveScene ().name == "Main Menu") {
			if (MainMenuAdCount >= 4) {
				AdManager.instance.ShowInterstitial ();
				MainMenuAdCount = 0;
			} else {
				MainMenuAdCount = MainMenuAdCount + 1;
			}
		}

		if (SceneManager.GetActiveScene ().name == "Gameplay") {
			AdManager.instance.ShowBanner ();
		}
	}

}
