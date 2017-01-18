using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class time : MonoBehaviour {
	private DateTime start = DateTime.Now;
	public List<int> shots = new List<int>();
	[SerializeField]
	public bool expired = false;
	[SerializeField]
	private int[] score = new int[2];

	void countdown (DateTime time_start)
	{	
		DateTime now = DateTime.Now;
		if ((now.Second - time_start.Second) >= 3 && !expired) {
			expired = true;
		}
    }

	// Use this for initialization
	void Start () {
		score[0] = 0;
		score[1] = 0;
	}
	
	// Update is called once per frame
	void Update () {
		countdown (start);
		if (shots.Count > 0) {
			score[shots[0]] += 1;
			Debug.Log (score);
			shots = new List<int> ();
		}
	}
}
