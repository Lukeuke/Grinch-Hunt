using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giftPickup : MonoBehaviour
{
    public int amount = 1;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
            LevelManager.instance.IncreaseGift(amount);
        }
    }
}
