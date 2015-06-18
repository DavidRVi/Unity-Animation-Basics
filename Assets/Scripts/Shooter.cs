using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public GameObject shoot;
	private GameObject reference;
	private bool shooting = false;
	private int count = 0;

	// Use this for initialization
	void Start () {
	
		reference = GameObject.FindGameObjectWithTag ("ShootReference");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(count < 1 && shooting)
		{
			count ++;
			RaycastHit hit;
			Vector3 enemyOnSight = Vector3.up;
			if(Physics.SphereCast (reference.transform.position, 10.0f, reference.transform.forward, out hit))
			{
				if(hit.collider.CompareTag ("Enemy"))
				{

					enemyOnSight = hit.transform.position;
				}
			}

			GameObject lazor = (GameObject) Instantiate (shoot, reference.transform.position, reference.transform.rotation);

			if(enemyOnSight != Vector3.up)
				lazor.GetComponent<LaserScript>().SetTarget(enemyOnSight);
			//laser.transform.Translate (Vector3.forward);
			//laser.transform.LookAt (


			//Esperamos unos segundos para poder volver a disparar
		}
		if(Input.GetButton("Fire1") && !shooting && count <1)
		{
			StartCoroutine (WaitAnimation ());
			StartCoroutine(WaitInterval ());
		}
	}


	IEnumerator WaitInterval(){
		yield return new WaitForSeconds(2.0f);
		count =0;
		shooting = false;
	}

	IEnumerator WaitAnimation(){
		yield return new WaitForSeconds(1.25f);
		shooting = true;
	}
}
