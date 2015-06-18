using UnityEngine;
using System.Collections;

public class TargetFinder : MonoBehaviour {


	private Vector3[] positions;
	// Use this for initialization
	void Start () {
	
		Transform[] targets = GetComponentsInChildren<Transform>();
		positions = new Vector3[targets.Length];
		RaycastHit hit;
		int index = 0;
		foreach(Transform t in targets)
		{
			if(Physics.Raycast(t.position, Vector3.down, out hit))
			{
				if(hit.collider.CompareTag("Terrain"))
				{
					positions[index] = hit.point;
					index++;
				}
			}
		}
	}
	
	public int GetNumTargets()
	{
		return positions.Length;
	}

	public Vector3 GetPosition(int index)
	{
		if(index < positions.Length)
			return positions[index];
		else return Vector3.up;
	}
}
