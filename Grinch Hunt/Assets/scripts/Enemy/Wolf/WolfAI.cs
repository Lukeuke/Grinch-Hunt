using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{
   public float speed;
   public float distance;
   private Transform target;
   public ParticleSystem particleWolf;

   public LayerMask groundLayers;

   public Transform wallcheck;
   public Rigidbody2D rb;

   RaycastHit2D hit;

   void Start() {
        hit = Physics2D.Raycast(wallcheck.position, -transform.up, 1f, groundLayers);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
   }

   void Update() {
       if(Vector2.Distance(transform.position, target.position) < distance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       }
   }

   private void FixedUpdate() {
         if (hit.collider != false) {
             {
                
             }
         }
     }

   private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy() {
        Instantiate(particleWolf, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
