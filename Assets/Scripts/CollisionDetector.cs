using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	public GameObject effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {

		if(collision.transform.CompareTag ("Disparo"))
		{		
			GameObject.Destroy (collision.gameObject);
			Instantiate (effect, collision.transform.position, Quaternion.identity);
			if(this.CompareTag ("Enemy"))
				GameObject.Destroy (this.gameObject);
		}
	}

}
