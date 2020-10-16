using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderboardController : MonoBehaviour {

	public static LeaderboardController instance;

	private const string leaderboardID = "CgkImp7jmJQcEAIQAQ";

	void Awake(){
		MakeSingleton ();

		PlayGamesPlatform.Activate ();

		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool success) => {
				
			});
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

	public void OpenLeaderboard(){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderboardID);
		} else {
			Social.localUser.Authenticate ((bool success) => {
				if(success){
					PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderboardID);
				} else {
					Debug.Log("User couldn't authenticate");
				}

			});
		}
	}

	public void PostScore(int score){
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, leaderboardID, (bool success) => {
				
			});
		}
	}

}
