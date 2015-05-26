using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if(this.gameObject.name == "Team0Bullet(Clone)" && other.transform.parent.name == "Team1PlayerController(Clone)")
		{
			Debug.Log ("Hit");
			Destroy(this.gameObject);
		}
		if(this.gameObject.name == "Team1Bullet(Clone)" && other.transform.parent.name == "Team0PlayerController(Clone)")
		{
			Debug.Log ("Hit");
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * 5* Time.deltaTime);
	}
}
