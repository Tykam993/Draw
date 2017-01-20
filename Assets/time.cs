using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System;

public class time : MonoBehaviour {
	// Is the game finished
	public bool game_over = true;
	// Variable to hold the new time to start each round
	private DateTime start;
	// List of shots fired by the players
	public List<int> shots = new List<int>();
	// Has the walk phase expired
	public bool expired = false;
	// Keeps track of the players' scores
	private int[] score = new int[2];
	// Player 1 object
	[SerializeField]
	private GameObject player1;
	// Player 2 object
	[SerializeField]
	private GameObject player2;
	// The Text used to display Player 1's score
	[SerializeField]
	private Text score_1;
	// The Text used to display Player 2's score
	[SerializeField]
	private Text score_2;
	private Text s1;
	private Text s2;
	// Text used to display the game over message
	[SerializeField]
	private GameObject game_text;
	Text gt;
	// Audio of the word Draw
	private AudioSource draw;
	// How long the walk phase lasts
	int rand;
	// Countsdown to check if the players should continue walking
	// Takes in a Datetime object marking the beginning of a round.
	// The beginning is compared to the current time to see if the walk
	// phase is over.  If not, the players keep walking
	private bool countdown (DateTime time_start, int round_duration)
	{
		DateTime now = DateTime.Now;
		if ((((now.Second - time_start.Second) >= round_duration) ||
			now.Second - time_start.Second <= (-59 + round_duration)) && !expired && !game_over) {
			expired = true;
			draw.Play ();
			return true;
		} else {
			
			return false;
		}
    }

	private bool test_countdown() {
		DateTime now = DateTime.Now;
		bool test_1 = countdown (now, 20) == false;
		Debug.Log (test_1);
		DateTime second = DateTime.Now;
		bool test_2 = countdown (second, 3);
		Debug.Log (test_2);
		return test_1 && test_2;
	}

	// Use this for initialization
	void Start () {
		score[0] = 0;
		score[1] = 0;
		s1 = score_1.GetComponent<Text> ();
		s2 = score_2.GetComponent<Text> ();
		draw = GetComponent<AudioSource> ();
		rand = Random.Range (2, 6);
		gt = game_text.GetComponent<Text> ();
		gt.text = "P1 fire with A, P2 fire with L.  S to start.";
	}
	
	// Update is called once per frame
	void Update () {
			// Prevents the game from running until started
			if (Input.GetKeyDown ("s")) {
				game_text.SetActive (false);
				game_over = false;
				start = DateTime.Now;
			}

			// Display the scores
			s1.text = score [0].ToString ();
			s2.text = score [1].ToString ();

			// Check to see if there is a winner
			if (score [0] == 3 || score [1] == 3) {
				game_over = true;
				expired = true;
				gt.text = "Game Over! Q to quit.";
				game_text.SetActive (true);
			}

			// If the game isn't over, run through each phase
			if (!game_over) {
				countdown (start, rand);
				// If a shot was fired, award the first player with a point
				if (shots.Count > 0) {
					if (score [shots [0]] < 3 || true) {
						score [shots [0]] += 1;
						// Reset the timer
						start = DateTime.Now;
						expired = false;
						rand = Random.Range (2, 6);
						// If the round ends and there is no winner, reset player positions
						if (!(score [0] == 3 || score [1] == 3)) {
							player1.transform.position = new Vector3 (-2, transform.position.y, transform.position.z);
							player2.transform.position = new Vector3 (2, transform.position.y, transform.position.z);
						}
					}
					// Reset the list of fired shots
					shots = new List<int> ();
				}
			}
		// If the game has ended, allow the user to close the game with q
		else {
				if (Input.GetKeyDown ("q")) {
					Application.Quit ();
				}
			}
		}
}

