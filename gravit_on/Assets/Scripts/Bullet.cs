using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject planet;
	public float accelerationScale;
	public Rigidbody rb;
	public float delVelocity;
	public float delHighLength;
	float shotVelocity;
	float floorLength;
	public int playerId;
	public Vector3 velocity { get; private set; }

	public static Bullet Instantiate (Bullet prefab, Vector3 velocity){
		Bullet obj = Instantiate (prefab) as Bullet;
		obj.velocity = velocity;
		return obj;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = velocity;
		floorLength = planet.transform.localScale.y/2;
	}
	
	// Update is called once per frame
	void Update () {
		var direction = planet.transform.position - transform.position;
		var length = direction.magnitude;
		direction.Normalize ();
		rb.AddForce (accelerationScale * direction, ForceMode.Acceleration);
		var player_list = Player.FindObjectsOfType<Player> ();
		foreach(Player player in player_list){
			if (playerId == player.playerId) {
				continue;
			}
			direction = player.transform.position - transform.position;
			direction.Normalize ();
			rb.AddForce (accelerationScale * direction, ForceMode.Acceleration);
		}

		if (rb.velocity.magnitude < delVelocity && length < floorLength) {
			Debug.Log ("Too Slow Despawn");
			GameObject.Destroy (this.gameObject);
		}
		if (length > delHighLength) {
			Debug.Log ("Too Far Despawn");
			GameObject.Destroy (this.gameObject);
		}
	}
}
