using UnityEngine;
using System.Collections;

public class EnemyAnimatorScript : MonoBehaviour {

	protected Animator animator;
	private enum State {IDLE = 0, WALKING = 1};

	private enemyAI current_state;
	// Use this for initialization
	void Start () {

		current_state = GetComponent<enemyAI>();
		animator = GetComponent<Animator>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(animator)
		{
			if((State) current_state.getCurrentState () == State.WALKING )
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
	}
}
