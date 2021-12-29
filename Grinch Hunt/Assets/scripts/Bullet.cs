using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed= 15f;
	public float bulletDamage = 10f;
	public Rigidbody2D rb;
	public float _timeToDestroy = 0f;

	public ParticleSystem particleDestroy;

	private void FixedUpdate() {
		rb.velocity = transform.right * bulletSpeed;
		Destroy(gameObject, _timeToDestroy);
	}
	
	private void OnCollisionEnter2D(Collision2D collision)  {
		pD();
		Destroy(gameObject);
	}

	private void pD() {
		Instantiate(particleDestroy, transform.position, Quaternion.identity);
	}
}


/*
	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Player") == false) {
			pD();
			Destroy(gameObject);
		} else {
			return;
		}
	}
*/