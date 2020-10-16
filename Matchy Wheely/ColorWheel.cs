using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheel : MonoBehaviour {

	public List<Material> currentMaterialsUsed = new List<Material>();

	List<Material> materialStorage = new List<Material>();

	public ColorWheelPiece[] colorWheelPieces;


	void Start(){

		SaveMaterials ();
		SetNewMaterialsForWheelPieces ();

	}


	Material GenerateRandomMaterial(){
	
		Material materialToReturn = null;

		int randomIndex = Random.Range (0, currentMaterialsUsed.Count);

		materialToReturn = currentMaterialsUsed [randomIndex];

		currentMaterialsUsed.Remove (currentMaterialsUsed [randomIndex]);

		return materialToReturn;
		
	}

	void SaveMaterials(){

		foreach (Material m in currentMaterialsUsed) {
			materialStorage.Add (m);
		}
	}


	void SetNewMaterialsForWheelPieces(){

		List<ColorWheelPiece> tempPieces = new List<ColorWheelPiece> ();

		foreach (ColorWheelPiece cP in colorWheelPieces) {
			tempPieces.Add (cP);

			Material m = GenerateRandomMaterial ();

			cP.SetCurrentMaterial (m);
		}

		foreach (Material m in materialStorage) {
			currentMaterialsUsed.Add (m);
		}

	}

}
