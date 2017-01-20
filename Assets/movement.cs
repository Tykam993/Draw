using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	// Game Object that handles time and scoring
	public GameObject time_keeper;
	// Is the walk phase over
	private bool time_expired;
	[SerializeField]
	// Which player is this?
	private int player_number;
	// What key does this player use to fire
	[SerializeField]
	private string key;

	// Use this for initialization
	void Start () {
		
	}

	// Move the players in the right directions
    void walk()
	{
		if (player_number == 0)
        {   
            Vector3 left = new Vector3(-.05f, 0, 0);
            transform.position += left;
        }
		if (player_number == 1)
        {
            Vector3 right = new Vector3(.05f, 0, 0);
            transform.position += right;
        }
    }

	// Shoot at the other player
	// Sends the player number to the time keeper.  This let's the time keeper know which
	// player shot first
	void fire_weapon() {
			time_keeper.GetComponent<time> ().shots.Add (player_number);

	}

	// Update is called once per frame
	void Update () {
		bool game_over = time_keeper.GetComponent<time> ().game_over;
		time_expired = time_keeper.GetComponent<time>().expired;
		// Walk until the duel starts
		if (!time_expired &&  !game_over) {
			walk ();
		}
		if (Input.GetKeyDown (key)) {
			if (time_expired) {
				fire_weapon ();
			}
		}
	}
}
