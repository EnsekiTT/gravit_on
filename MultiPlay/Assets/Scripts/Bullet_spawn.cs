using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Bullet_spawn : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public float forwardSpeed = 10f;
	public float upSpeed = 5f;
	public float duration = 3f;

	[ClientCallback]
	void Update()
	{
		if (isLocalPlayer && Input.GetMouseButtonDown(0)) {
			var forward = Camera.main.transform.forward;
			var up = Camera.main.transform.up;
			var velocity = forward * forwardSpeed + up * upSpeed;
			CmdShoot(velocity);
		}
	}

	[Command]
	void CmdShoot(Vector3 velocity)
	{
		var bullet = Instantiate(bulletPrefab);
		bullet.transform.position = transform.position + velocity.normalized * 0.5f;
		var rigidbody = bullet.GetComponent<Rigidbody>();
		if (rigidbody) {
			rigidbody.velocity = velocity;
		}
		NetworkServer.Spawn(bullet);
		StartCoroutine(DestroyBullet(bullet));
	}

	[Server]
	IEnumerator DestroyBullet(GameObject bullet)
	{
		yield return new WaitForSeconds(duration);
		NetworkServer.Destroy(bullet);
		Destroy(bullet); // 要るか要らないかまだ不明...
	}
}