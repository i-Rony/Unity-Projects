using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorWheelPiece : MonoBehaviour {


	public void SetCurrentMaterial(Material m){
		GetComponent<Renderer> ().material = m;
	}

	void OnTriggerEnter(Collider collider){
		string pieceMaterialName = GetComponent<Renderer> ().material.name.Replace (" (Instance)", "");

		if (collider.GetComponent<Ball> () != null) {
			if (collider.GetComponent<Ball> ().ballType.ToString () == pieceMaterialName) {
				if (collider.GetComponent<Ball> ().IsSpecial == true) {
					GameplayController.instance.GameScore = GameplayController.instance.GameScore + 2;
				} else {
					GameplayController.instance.GameScore++;
				}

				Destroy (collider.gameObject);

				if (GameObject.FindObjectOfType<BallSpawnManager> ().spawnSpecialBall == true) {
					GameObject.FindObjectOfType<BallSpawnManager> ().spawnSpecialBall = false;
				}

				GameplaySoundManager.instance.PlayScoreSound ();

			} else {
				GameOver ();
			}
		}
	}


	void GameOver(){

		if (GameManager.instance.GameOverAdCount >= 8) {
			AdManager.instance.ShowInterstitial ();
			GameManager.instance.GameOverAdCount = 0;
		} else {
			GameManager.instance.GameOverAdCount = GameManager.instance.GameOverAdCount + 1;
		}

		if (GameplayController.instance.GameScore > GameManager.instance.HighScore) {
			GameManager.instance.HighScore = GameplayController.instance.GameScore;

			LeaderboardController.instance.PostScore (GameplayController.instance.GameScore);
		}

		GameObject[] ballsInGame = GameObject.FindGameObjectsWithTag ("Ball");

		foreach (GameObject g in ballsInGame) {
			Destroy (g);
		}

		GameplayController.instance.gameScoreText.CrossFadeAlpha (0f, 2f, true);
		GameplayController.instance.pauseButton.GetComponent<Image> ().CrossFadeAlpha (0f, 2f, true);

		Time.timeScale = 0f;

		SceneManager.LoadScene ("Game Over", LoadSceneMode.Additive);
	}
}
