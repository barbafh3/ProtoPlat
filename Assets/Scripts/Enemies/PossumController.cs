using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossumController : MonoBehaviour
{

  bool _isFacingRight = false;

  public float speed = 2f;

  float _direction = 1f;

  public Rigidbody2D _rb2d = null;

  // Start is called before the first frame update
  void Start()
  {
    // _rb2d.velocity = new Vector2(1f * speed, _rb2d.velocity.y);
  }

  // Update is called once per frame
  void Update()
  {
    _rb2d.velocity = new Vector2(_direction * speed, _rb2d.velocity.y);
    if (_rb2d.velocity.x > 0 && !_isFacingRight)
    {
      Flip();
    }
    else if (_rb2d.velocity.x < 0 && _isFacingRight)
    {
      Flip();
    }
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.tag == "Player")
    {
      col.gameObject.GetComponent<PlayerController>().TakeHit(gameObject, 1f);
    }
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Ground")
    {
      _direction *= -1;
    }
    if (col.gameObject.tag == "Player")
    {
      Destroy(gameObject);
      col.gameObject.GetComponent<PlayerController>().Jump();
      Debug.Log("Dead possum");
    }
  }

  void Flip()
  {
    _isFacingRight = !_isFacingRight;
    Vector2 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
}
