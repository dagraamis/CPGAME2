using UnityEngine;
using System.Collections;

public class RangedWeapon : MonoBehaviour {
	public enum WeaponState
	{
		Idle,
		Shooting,
	}
	public int team;
	public float ShootDelay;
	public WeaponState weaponState;
	// Use this for initialization
	void Start () {
		
	}
	[RPC]
	void FireOneShot(int team2)
	{

		if(ShootDelay != 20f)
		{
			ShootDelay += 1;
		}
		else
		{
			Debug.Log ("Shooting");
			if(team2 == 1)
			{
				PhotonNetwork.Instantiate("Team1Bullet", new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), this.transform.rotation, 0);
			}
			if(team2 == 0)
			{
				PhotonNetwork.Instantiate("Team0Bullet", new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), this.transform.rotation, 0);
			}
			ShootDelay = 0;
		}
	}	
	[RPC]
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			if(this.name == "Team1PlayerController(Clone)")
			{
				FireOneShot (1);
			}
			if(this.name == "Team0PlayerController(Clone)")
			{
				FireOneShot(0);
			}
		}
	}
}
