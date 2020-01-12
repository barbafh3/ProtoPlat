using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public Rigidbody2D rb;

  public Animator animator;

  public float speed = 5f;

  public float jumpHeight = 20f;

  bool _isJumping = false;

  bool _isFacingRight = true;

  public Vector2 startPosition;

  // Update is called once per frame
  void Update()
  {
    float moveHorizontal = GetMovement();

    animator.SetBool("isJumping", _isJumping);

    CheckFlip(moveHorizontal);

    if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
    {
      Jump();
    }

    if (rb.velocity.y < -0.01)
    {
      animator.SetBool("isFalling", true);
    }
  }

  void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.tag == "Ground")
    {
      _isJumping = false;
    }
  }

  private float GetMovement()
  {
    var moveHorizontal = Input.GetAxisRaw("Horizontal");
    animator.SetFloat("Horizontal", Mathf.Abs(moveHorizontal));
    var movement = new Vector2(moveHorizontal * speed, rb.velocity.y);

    rb.velocity = movement;
    return moveHorizontal;
  }

  private void CheckFlip(float moveHorizontal)
  {
    if (moveHorizontal > 0 && !_isFacingRight)
    {
      Flip();
    }
    else if (moveHorizontal < 0 && _isFacingRight)
    {
      Flip();
    }
  }

  public void Jump()
  {
    rb.velocity = Vector2.zero;
    _isJumping = true;
    animator.SetBool("isFalling", false);
    rb.AddForce(Vector2.up * jumpHeight);
  }


  void Flip()
  {
    _isFacingRight = !_isFacingRight;
    Vector2 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }

  public void TakeHit(GameObject source, float damage)
  {
    if (GameManager.Instance.currentHealth > 0)
    {
      GameManager.Instance.currentHealth -= damage;
      animator.Play("Hit");
    }
  }

}
