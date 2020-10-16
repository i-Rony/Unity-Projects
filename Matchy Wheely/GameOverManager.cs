using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Text gameScoreText;
	public Text highScoreText;

	void Start(){
		gameScoreText.text = "Score: " + GameplayController.instance.GameScore.ToString ();
		highScoreText.text = "High Score: " + GameManager.instance.HighScore.ToString();

		GameObject.FindObjectOfType<Animator> ().Play ("GameOverPanelSlideIn");
	}

	public void GoToMainMenu(){
		SceneFader.instance.FadeInMainMenu ();
	}

	public void ReplayGame(){
		SceneFader.instance.FadeInGameplay ();
	}
}
