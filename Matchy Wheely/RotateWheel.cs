using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateWheel : MonoBehaviour {

	//Getting reference to our color wheel
	public GameObject colorWheel;

	RotateMode rMode = RotateMode.LocalAxisAdd;

	private readonly float rotationAmount = 90f;
	private readonly float rotationTime = 0.2f;

	public void RotateRight(){
		colorWheel.transform.DORotate (new Vector3 (colorWheel.transform.rotation.x + rotationAmount, 0, 0), rotationTime, rMode);
	}

	public void RotateLeft(){
		colorWheel.transform.DORotate (new Vector3 (colorWheel.transform.rotation.x - rotationAmount, 0, 0), rotationTime, rMode);
	}
}
