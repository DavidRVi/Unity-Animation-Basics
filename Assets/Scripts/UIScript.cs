using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	private int curr_enemies;
	private int total_enemies;

	public Text winText;
	// Use this for initialization
	void Start () {
	
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		total_enemies = enemies.Length;
		curr_enemies = total_enemies;
		GetComponent<Text>().text = "Enemigos: " + curr_enemies.ToString () + "/" + total_enemies.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		if(curr_enemies != enemies.Length)
		{
			curr_enemies = enemies.Length;
			GetComponent<Text>().text = "Enemigos: " + curr_enemies.ToString () + "/" + total_enemies.ToString ();
		}

		if(enemies.Length == 0)
			winText.gameObject.SetActive(true);
	}
}
