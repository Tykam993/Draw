using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class time : MonoBehaviour {
	bool game_over = false;
	private DateTime start = DateTime.Now;
	public List<int> shots = new List<int>();
	[SerializeField]
	public bool expired = false;
	[SerializeField]
	private int[] score = new int[2];
	[SerializeField]
	private GameObject player1;
	[SerializeField]
	private GameObject player2;
	[SerializeField]
	private Text score_1;
	[SerializeField]
	private Text score_2;
	private Text s1;
	private Text s2;


	void countdown (DateTime time_start)
	{	
		DateTime now = DateTime.Now;
		if ((now.Second - time_start.Second) >= 3 && !expired) {
			expired = true;
			return;
		}
    }

	// Use this for initialization
	void Start () {
		score[0] = 0;
		score[1] = 0;
		Debug.Log (score);
		Debug.Log (score[0]);
		Debug.Log (score[1]);
		s1 = score_1.GetComponent<Text> ();
		s2 = score_2.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		s1.text = score [0].ToString ();
		s2.text = score [1].ToString ();
		if (score [0] == 3 || score [1] == 3) {
			game_over = true;
			expired = true;
		}
		if (!game_over) {
			countdown (start);
			if (shots.Count > 0) {
				if (score [shots [0]] < 3) {
					score [shots [0]] += 1;
					start = DateTime.Now;
					expired = false;
					if (!(score[0] == 3 || score[1] == 3)){
						player1.transform.position = new Vector3 (-2, transform.position.y, transform.position.z);
						player2.transform.position = new Vector3 (2, transform.position.y, transform.position.z);
					}
				}
				Debug.Log (score);
				shots = new List<int> ();
			}
		}
		else {
			if (Input.GetKeyDown ("a")) {
				UnityEditor.EditorApplication.isPlaying = false;
			}
		}




	}
}

