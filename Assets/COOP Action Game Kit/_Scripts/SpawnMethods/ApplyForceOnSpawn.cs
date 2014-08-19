using UnityEngine;
using System.Collections;

public class ApplyForceOnSpawn : MonoBehaviour {

	public bool ApplyRandomDrag=true;
	public float RandomDragMin=0.4f;
	public float RandomDragMax=1f;
	public bool ApplyTorqueY=true;
	public float RandomTorqueYForce=15f;
	public float UpRandomForce=4f;
	public float RandomForce=4f;

	void OnEnable() {
		if(gameObject.rigidbody) {
			gameObject.rigidbody.drag = Random.Range(RandomDragMin, RandomDragMax);
			if(ApplyTorqueY)
				gameObject.rigidbody.AddRelativeTorque(Vector3.up * Random.Range(-2,2f)*RandomTorqueYForce);
			gameObject.rigidbody.AddForce(Random.Range(-1,1f)*RandomForce,Random.Range(0,1f)*UpRandomForce,Random.Range(-1,1f)*RandomForce,ForceMode.Impulse);
		}
	}
}
