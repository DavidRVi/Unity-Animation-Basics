using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 10.0f;
	public float gravity = 20.0f;
	protected CharacterController controller;
	protected Animator anim;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);


		//Si no esta disparando, nos movemos.
		if(!stateInfo.IsName ("Base Layer.Shooting"))
		{
			transform.Rotate(0.0f, h * 2.0f, 0.0f);

			Vector3 forward = transform.TransformDirection(Vector3.forward);
			forward = forward * v;
			forward = forward * speed;
			forward.y -= gravity * Time.deltaTime;
			controller.Move(forward * Time.deltaTime);
		}
	}
}
