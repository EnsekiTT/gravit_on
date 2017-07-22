using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMuzzle : MonoBehaviour {
	public Bullet bullet;
	public GameObject muzzle;
	public float speed;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			// 弾丸の複製
			Bullet bullets = Bullet.Instantiate(bullet, new Vector3(0f,0f,0f));

			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			// Rigidbodyに力を加えて発射
			bullets.GetComponent<Rigidbody> ().AddForce (force);
			// 弾丸の位置を調整
			bullets.transform.position = muzzle.transform.position;
		}
	}
}
