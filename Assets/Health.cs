using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int health = 100;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Team0Bullet(Clone)" && this.gameObject.name == "Team1PlayerController(Clone)")
		{
			Debug.Log ("Hit");
			Destroy(col.gameObject);
			health -= 10;
		}
		if(col.gameObject.name == "Team1Bullet(Clone)" && this.gameObject.name == "Team0PlayerController(Clone)")
		{
			Debug.Log ("Hit");
			Destroy(col.gameObject);
			health -= 10;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
