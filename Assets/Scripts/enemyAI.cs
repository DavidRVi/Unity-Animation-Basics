using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {


	protected NavMeshAgent agent;

	private enum State {IDLE = 0, WALKING=1, WAITING=2};
	private State current_state;

	public float radius = 15.0f;

	public GameObject reference;
	private TargetFinder tf;

	private int current_target;
	private bool inactive = false;
	private Vector3 next_pos;
	// Use this for initialization
	void Start () {
	
		current_state = State.IDLE;
		agent = GetComponent<NavMeshAgent>();
		tf = reference.GetComponent<TargetFinder>();
		current_target = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		switch(current_state)
		{
		case(State.IDLE):
			inactive = false;
			if(current_target >= tf.GetNumTargets ())
				current_target = 0;
			next_pos = tf.GetPosition (current_target);
			if(next_pos != Vector3.up)
			{
				current_state = State.WALKING;
			}
			break;
		case(State.WALKING):
			agent.SetDestination (next_pos);
			if(!agent.pathPending)
			{
				if(agent.remainingDistance <= agent.stoppingDistance)
				{
					if(!agent.hasPath || agent.velocity.sqrMagnitude == 0.0f)
						current_state = State.WAITING;
				}
			}
			break;
		case(State.WAITING):
			if(!inactive)
			{
				inactive = true;
				StartCoroutine (Inactive());
			}
			break;
		}


	}

	IEnumerator Inactive()
	{
		yield return new WaitForSeconds(2.0f);
		current_state = State.IDLE;
		current_target ++;
	}


	public int getCurrentState()
	{
		return (int) current_state;
	}
}
