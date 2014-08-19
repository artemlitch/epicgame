using UnityEngine;
using System.Collections;

public class PickRandomMaterial : MonoBehaviour {

	public Material[] PickFromMaterials;

	// Use this for initialization
	void OnEnable () {
		gameObject.renderer.material = PickFromMaterials [Random.Range (0, PickFromMaterials.Length)];
	}

}
