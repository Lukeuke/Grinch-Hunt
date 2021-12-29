using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{

    public ParticleSystem particleSnow;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy() {
        Instantiate(particleSnow, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
