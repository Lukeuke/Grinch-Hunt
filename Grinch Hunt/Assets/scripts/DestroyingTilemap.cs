using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyingTilemap : MonoBehaviour
{
    public Tilemap destroyingTilemap;

    private void Start() {
        destroyingTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet")) {
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts) {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                destroyingTilemap.SetTile(destroyingTilemap.WorldToCell(hitPosition), null);
            }
        }
    }
}
