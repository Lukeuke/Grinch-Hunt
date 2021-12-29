using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointCounter : MonoBehaviour
{
    public Transform checkpoint;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            checkpoint.position = transform.position;
            Debug.Log("Player has passed!");
        }
    }
}