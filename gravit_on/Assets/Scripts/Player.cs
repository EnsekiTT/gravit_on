using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public GameObject planet;
	public float movementSpeed;
	public float movementSpeedRun;
	public float accelerationScale;
	public float azRotateSpeed;
	private Rigidbody rb;
	private bool floorTouch;

	public Bullet bullet;
	public GameObject muzzle;
	public float speed;

	// Player status
	public int playerId;
	public int score;
	public int hitPoint;
	public int bullets;
	public int hitCount;
	public int killCount;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		floorTouch = true;

		//status
		playerId = 0;
		score = 0;
		hitPoint = 100;
		bullets = 1000;
		hitCount = 0;
		killCount = 0;

		var randX = Random.Range (-1f, 1f);
		var randY = Random.Range (-1f, 1f);
		var randZ = Random.Range (-1f, 1f);
		var angle = Random.Range (-180f, 180f);
		Vector3 axis = new Vector3 (randX, randY, randZ).normalized;
		transform.RotateAround (planet.transform.position, axis, angle);
		transform.position = transform.up * (planet.transform.localScale.y/2.0f);
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//向きを変える
		score++;
		var azRotation = Input.GetAxis ("Mouse X") * azRotateSpeed;
		transform.Rotate (0, azRotation, 0);

		// 重力方向を頭にして立つ
		var gravityUp = (transform.position - planet.transform.position).normalized;
		var targetVector = transform.position + transform.forward;
		transform.up = gravityUp;
		targetVector = transform.InverseTransformPoint (targetVector);
		targetVector.y = 0;
		targetVector = transform.TransformPoint (targetVector);
		transform.LookAt (targetVector, gravityUp);

		// 動き回るところ
		var moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
		var movementSpeedGain = movementSpeed;
		if (Input.GetKey (KeyCode.LeftShift)) {
			movementSpeedGain = movementSpeedRun;
		}
		var movePosition = transform.TransformDirection (moveDirection * movementSpeedGain);
		rb.MovePosition(rb.position + movePosition);

		// 重力を出すところ
		rb.AddForce(gravityUp * -1 * accelerationScale);

		// ジャンプするところ
		if (Input.GetKeyDown(KeyCode.Space) && floorTouch)
		{
			rb.velocity = gravityUp * 10;
			floorTouch = false;
		}

		if(Input.GetMouseButton(0) && bullets > 0){
			bullets--;
			// 弾丸の複製
			Bullet bullets_obj = Bullet.Instantiate(bullet, new Vector3(0,0,0));
			bullets_obj.playerId = playerId;
			Vector3 force;
			force = muzzle.transform.forward * speed;
			// Rigidbodyに力を加えて発射
			bullets_obj.GetComponent<Rigidbody> ().AddForce (force);
			// 弾丸の位置を調整
			bullets_obj.transform.position = muzzle.transform.position;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name != "Bullet(Clone)") {
			floorTouch = true;
		}
		if (collision.gameObject.name == "Bullet(Clone)") {
			hitPoint--;
			if (hitPoint <= 0) {
				//
				SceneManager.LoadScene ("Menu");
			}
		}
	}
}
