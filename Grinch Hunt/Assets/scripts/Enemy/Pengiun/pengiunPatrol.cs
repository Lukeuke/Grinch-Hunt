using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pengiunPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;

    public Transform groundCheck;

    public bool isFacingRight = true;

    public ParticleSystem snow;

    RaycastHit2D hit;

    private void Update() {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

     private void FixedUpdate() {
         if (hit.collider != false) {
             if (isFacingRight) {
                 rb.velocity = new Vector2(speed, rb.velocity.y);
                 CreateSnow();
             } else {
                  rb.velocity = new Vector2(-speed, rb.velocity.y);
                  CreateSnow();
             }
         } else {
             isFacingRight = !isFacingRight;
             transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
         }
     }

     void CreateSnow() {
      snow.Play();
    }
}