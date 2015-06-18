using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	private float speed = 100.0f;
	private Rigidbody rb;

	private Vector3 target;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		StartCoroutine (WaitToDie ());
	}
	
	// Update is called once per frame
	void Update () {
	
		if(target != Vector3.zero)
		{

			rb.MovePosition (transform.position + target * speed * Time.deltaTime);
		}
		else rb.MovePosition (transform.position + transform.forward * speed * Time.deltaTime);
		//this.transform.Translate (this.transform.forward * speed * Time.deltaTime);
	}

	IEnumerator WaitToDie(){
		yield return new WaitForSeconds(5.0f);
		GameObject.Destroy (this.gameObject);
	}

	public void SetTarget(Vector3 point)
	{
		this.target = point;
		target = target + new Vector3(0.0f, 1.0f, 0.0f);
		Vector3 direction = target - transform.position;
		direction.Normalize ();
		target = direction;
	}
}
