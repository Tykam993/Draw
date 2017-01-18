using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    [SerializeField]
    private string direction;

	public GameObject time_keeper;
	private bool time_expired;
	[SerializeField]
	private int player_number;
	[SerializeField]
	private string key;

	// Use this for initialization
	void Start () {
		
	}

	void reset_position() {
		transform.position = new Vector3 (0, transform.position.y, transform.position.z);
	}

    void walk(string dir)
	{
        if (direction == "left")
        {   
            Vector3 left = new Vector3(-.05f, 0, 0);
            transform.position += left;
        }

        if (direction == "right")
        {
            Vector3 right = new Vector3(.05f, 0, 0);
            transform.position += right;
        }
    }

	void fire_weapon() {
			time_keeper.GetComponent<time> ().shots.Add (player_number);

	}

	// Update is called once per frame
	void Update () {
		time_expired = time_keeper.GetComponent<time>().expired;
		if (!time_expired) {
			walk (direction);
		}
		if (Input.GetKeyDown (key)) {
			if (time_expired) {
				fire_weapon ();
			}
		}
	}
}
