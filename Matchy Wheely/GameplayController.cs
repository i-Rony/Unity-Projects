using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;


	public Text gameScoreText;
	public Button pauseButton;

	private int gameScore;
	public int GameScore { get{ return gameScore;} set{ gameScore = value; } }

	void Awake(){

		MakeInstance ();
	}

	void MakeInstance(){
		if (instance == null)
			instance = this;
	}

	void Start(){
		gameScore = 0;
	}

	void Update(){
		gameScoreText.text = gameScore.ToString ();
	}

	public void OpenPauseMenu(){
		if (SceneManager.sceneCount < 2) {
			SceneManager.LoadScene ("Pause Menu", LoadSceneMode.Additive);

		}
	}

}
