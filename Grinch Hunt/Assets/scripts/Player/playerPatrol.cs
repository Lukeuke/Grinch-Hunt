using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPatrol : MonoBehaviour
{
    public LayerMask trailLayers;

    public Transform trailCheck;

    public ParticleSystem snow;

    RaycastHit2D hit;

    private void Update() {
        hit = Physics2D.Raycast(trailCheck.position, -transform.up, 1f, trailLayers);
    }

     private void FixedUpdate() {
        if (hit.collider != false) {
            CreateSnow();
        } else {
            return;
        }
     }

    void CreateSnow() {
      snow.Play();
    }
}
