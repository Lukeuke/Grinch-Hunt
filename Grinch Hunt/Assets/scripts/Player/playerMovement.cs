using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
   public float movementSpeed;
   public Rigidbody2D rb;
   
   public Animator anim;

   public float jumpForce = 20f;
   public Transform feet;
   public LayerMask groundLayers;
   public LayerMask LadderLayer;
   public LayerMask waterLayer;
   public LayerMask platformLayer;
  
   [HideInInspector] public bool isFacingRight = true;

   private float mx;
   private float my;

   private void Update()
   {
      mx = Input.GetAxisRaw("Horizontal");
      my = Input.GetAxisRaw("Vertical");

      if (Input.GetButtonDown("Jump") && IsGrounded() && !IsClimbing())
      {
         Jump();
      }

      if (Mathf.Abs(mx) > 0.05f)
      {
         anim.SetBool("IsRunning", true);
      }
      else
      {
         anim.SetBool("IsRunning", false);
      }
      
      if (mx > 0f)
      {
         transform.localScale = new Vector3(3f, 3f, 3f);
         isFacingRight = true;
      }
      else if(mx < 0f)
      {
         transform.localScale = new Vector3(-3f, 3f, 3f);
         isFacingRight = false;
      }

      if (Mathf.Abs(my) == 0f) // ustawianie animacji wspinania
      {
         anim.SetBool("Climbing", false);
      } else if(Mathf.Abs(my) == 0f && IsClimbing()) {
         anim.SetBool("Climbing", true);
      }

      if (Mathf.Abs(mx) > 0.05f && IsSwimming())
      {
         anim.SetBool("IsRunning", false);
         anim.SetBool("IsSwim", true);
         movementSpeed = 7f;
      }
      else
      {
         anim.SetBool("IsSwim", false);
         movementSpeed = 10f;
      }

      anim.SetBool("IsGrounded", IsGrounded());
   }

   private void FixedUpdate() // movement - wchodzenie po drbinie 
   {
      Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

      rb.velocity = movement;

      if(my > 0 && IsClimbing() && mx == 0f) {
         anim.SetBool("Climbing", true);
         rb.transform.position += Vector3.up * movementSpeed * Time.fixedDeltaTime;
      }

      if(IsClimbing()) {
         rb.gravityScale = 0;
      }

      if(!IsClimbing()) {
         rb.gravityScale = 2;
         anim.SetBool("Climbing", false);
      }
   }

   void Jump()
   {
      Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

      rb.velocity = movement;
   }

   private bool IsGrounded()
   {
      Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

      if (groundCheck != null)
      {
         return true;
      }

      return false;
   }

   private bool IsClimbing() {
      Collider2D ladderCheck = Physics2D.OverlapCircle(feet.position, 0.5f, LadderLayer);

      if (ladderCheck != null)
      {
         return true;
      }

      return false;
   }

   private bool IsSwimming()
   {
      Collider2D waterCheck = Physics2D.OverlapCircle(feet.position, 0.5f, waterLayer);

      if (waterCheck != null)
      {
         return true;
      }
      return false;
   }

   
}


