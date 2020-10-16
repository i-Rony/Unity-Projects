using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour {

	public GameObject ballPrefab;
	public GameObject particlePrefab;

	public float spawnCD = 6f;
	public float spawnCDLeft;

	private float ballSpeed;
	public float BallSpeed { get{ return ballSpeed; } set { ballSpeed = value;} }

	public Material[] mats;

	[HideInInspector]
	public int nextSpecialBallSpawnScore;

	[HideInInspector]
	public bool spawnSpecialBall = false;

	void Start(){
		spawnCDLeft = 0f;

		ballSpeed = 10f;
	}

	void Update(){
		spawnCDLeft -= Time.deltaTime;

		if (spawnCDLeft <= 0) {
			SpawnBall ();
			spawnCDLeft = spawnCD;
		}

		int scoreDiv = GameplayController.instance.GameScore % 10;

		if (scoreDiv == 0 && spawnSpecialBall == false) {
			int random = Random.Range (1, 10);
			nextSpecialBallSpawnScore = GameplayController.instance.GameScore + random;
			spawnSpecialBall = true;
		}
			
	}

	void SpawnBall(){

		GameObject ball = (GameObject)Instantiate (ballPrefab, GenerateRandomSpawnPosition (), Quaternion.identity);
		ball.GetComponent<Ball> ().SetMaterialOfBall (GenerateRandomMaterial ());


		string ballMatName = ball.GetComponentInChildren<Renderer> ().material.name.Replace (" (Instance)", "");
	
		switch (ballMatName) {
		case "Blue":
			ball.GetComponent<Ball> ().ballType = BallType.Blue;
			break;
		case "Red":
			ball.GetComponent<Ball> ().ballType = BallType.Red;
			break;
		case "Green":
			ball.GetComponent<Ball> ().ballType = BallType.Green;
			break;
		case "Yellow":
			ball.GetComponent<Ball> ().ballType = BallType.Yellow;
			break;
		}


		if (GameplayController.instance.GameScore == nextSpecialBallSpawnScore) {
			switch (ballMatName) {
			case "Blue":

				Color blue = new Color (0, 107, 255);
				GameObject pS = (GameObject)Instantiate (particlePrefab, ball.transform);
				pS.transform.localPosition = new Vector3 (0, 0, 0);
				ParticleSystem.MainModule pSSettings = pS.GetComponent<ParticleSystem> ().main;
				pSSettings.startColor = new ParticleSystem.MinMaxGradient (blue);
				ball.GetComponent<Ball> ().IsSpecial = true;

				break;
			case "Red":

				Color red = new Color (255, 0, 0);
				GameObject pSRed = (GameObject)Instantiate (particlePrefab, ball.transform);
				pSRed.transform.localPosition = new Vector3 (0, 0, 0);
				ParticleSystem.MainModule pSSettingsRed = pSRed.GetComponent<ParticleSystem> ().main;
				pSSettingsRed.startColor = new ParticleSystem.MinMaxGradient (red);
				ball.GetComponent<Ball> ().IsSpecial = true;

				break;
			case "Yellow":
				Color yellow = new Color (255, 237, 0);
				GameObject pSYellow = (GameObject)Instantiate (particlePrefab, ball.transform);
				pSYellow.transform.localPosition = new Vector3 (0, 0, 0);
				ParticleSystem.MainModule pSSettingsYellow = pSYellow.GetComponent<ParticleSystem> ().main;
				pSSettingsYellow.startColor = new ParticleSystem.MinMaxGradient (yellow);
				ball.GetComponent<Ball> ().IsSpecial = true;

				break;
			case "Green":
				Color green = new Color (0, 255, 0);
				GameObject pSGreen = (GameObject)Instantiate (particlePrefab, ball.transform);
				pSGreen.transform.localPosition = new Vector3 (0, 0, 0);
				ParticleSystem.MainModule pSSettingsGreen = pSGreen.GetComponent<ParticleSystem> ().main;
				pSSettingsGreen.startColor = new ParticleSystem.MinMaxGradient (green);
				ball.GetComponent<Ball> ().IsSpecial = true;

				break;
			}

		}
			



		ball.GetComponent<Ball> ().MoveBallTowardsCenter (ballSpeed);


	}

	Material GenerateRandomMaterial(){
		int randomIndex = Random.Range (0, mats.Length);
		return mats [randomIndex];
	}

	float RandomZ(){

		float randomZ;
		float randomIndex = Random.value;


		randomZ = randomIndex * 50;
		return randomZ;
		
	}

	float RandomY(){
		float randomY;
		float randomIndex = Random.value;

		if (randomIndex <= 0.5) {
			randomY = randomIndex * -50;
			return randomY;
		} else {
			randomY = randomIndex * 50;
			return randomY;
		}
	}

	Vector3 GenerateRandomSpawnPosition(){

		float randomNum = Random.value;

		if (randomNum <= 0.5) {
			Vector3 spawnPosition = new Vector3 (GameObject.FindObjectOfType<ColorWheel> ().transform.position.x, RandomY (), -RandomZ ());
			return spawnPosition;
		} else {
			Vector3 spawnPosition = new Vector3 (GameObject.FindObjectOfType<ColorWheel> ().transform.position.x, RandomY (), RandomZ ());
			return spawnPosition;
		}

	}
}
