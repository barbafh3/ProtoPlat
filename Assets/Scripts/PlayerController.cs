using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  Rigidbody2D _rb2d;

  Animator _animator;

  public float speed = 5f;

  public float jumpHeight = 20f;

  public bool isJumping = false;

  public bool facingRight = true;

  // Start is called before the first frame update
  void Start()
  {
    _rb2d = GetComponentInChildren<Rigidbody2D>();
    _animator = GetComponentInChildren<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    var moveHorizontal = Input.GetAxisRaw("Horizontal");
    _animator.SetFloat("Horizontal", Mathf.Abs(moveHorizontal));
    var movement = new Vector2(moveHorizontal * speed, _rb2d.velocity.y);

    _rb2d.velocity = movement;

    _animator.SetBool("isJumping", isJumping);

    if (moveHorizontal > 0 && !facingRight)
    {
      Flip();
    }
    else if (moveHorizontal < 0 && facingRight)
    {
      Flip();
    }

    if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
    {
      Jump();
    }

    if (_rb2d.velocity.y < -0.01)
    {
      _animator.SetBool("isFalling", true);
    }

  }

  private void Jump()
  {
    _rb2d.velocity = Vector2.zero;
    isJumping = true;
    _animator.SetBool("isFalling", false);
    _rb2d.AddForce(Vector2.up * jumpHeight);
  }

  void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.tag == "Ground")
    {
      isJumping = false;
      //   _animator.SetBool("isJumping", isJumping);
    }
  }

  void Flip()
  {
    facingRight = !facingRight;
    Vector2 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }

}
