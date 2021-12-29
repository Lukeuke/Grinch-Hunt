using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public Transform checkpoint;
   public ParticleSystem blood;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy") || (collision.gameObject.CompareTag("Penguin"))) {
            Instantiate(blood, transform.position, Quaternion.identity);
            RespawnPlayer();
        }
    }

    private void RespawnPlayer() {
        transform.position = checkpoint.position;
    }
}
