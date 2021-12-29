using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerDeath : MonoBehaviour
{
    public ParticleSystem blood;

    /*private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy") || (collision.gameObject.CompareTag("Penguin"))) {
            Destroy();
        }
    }

    public void Destroy() {
        Instantiate(blood, transform.position, Quaternion.identity);

        Destroy(gameObject);

        LevelManager.instance.Respawn();
    } */
}
