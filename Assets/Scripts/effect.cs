using UnityEngine;
using System.Collections;

public class effect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitToDie());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	IEnumerator WaitToDie(){
		yield return new WaitForSeconds(2.0f);
		GameObject.Destroy (this.gameObject);
	}
}
