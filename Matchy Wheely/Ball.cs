using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum BallType { Blue, Red, Green, Yellow }

public class Ball : MonoBehaviour {

	[HideInInspector]
	public Material currentMaterial;

	private Vector3 targetPosition;

	public BallType ballType;

	private bool isSpecial;
	public bool IsSpecial { get{ return isSpecial;} set{ isSpecial = value; }}

	void Awake(){
		targetPosition = GameObject.FindObjectOfType<ColorWheel> ().transform.position;
	}

	void Update(){
		//SAFETY MEASURE!
		if (this.transform.position == targetPosition) {
			Destroy (gameObject);
		}
	}

	public void SetMaterialOfBall(Material m){
		this.GetComponentInChildren<Renderer> ().material = m;
		currentMaterial = m;
	}

	public void MoveBallTowardsCenter(float duration){
		this.transform.DOMove (targetPosition, duration);
	}
}
