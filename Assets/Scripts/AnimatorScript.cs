using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour {

	protected Animator animator;

	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {
	
		if(animator)
		{
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);

			if(stateInfo.IsName ("Base Layer.Idle") || stateInfo.IsName ("Base Layer.Walking"))
			{
				if(Input.GetButton ("Fire1")) animator.SetBool ("Shooting", true);
				else if(Input.GetAxis ("Horizontal") != 0.0f || Input.GetAxis ("Vertical") != 0.0f)
				{
					animator.SetBool("Walking", true);
					animator.SetBool ("Idle", false);
				}
				else
				{
					animator.SetBool ("Idle", true);
					animator.SetBool("Walking", false);
				}
			}
			else animator.SetBool ("Shooting", false);
		}
	}
}
