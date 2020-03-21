using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{

  public float speed = 50f;

  float _direction = 1f;

  public float xVel = 0f;

  public Rigidbody2D _rb2d = null;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    xVel = _rb2d.velocity.x;
    var player = GameObject.Find("Player").transform;
    var direction = (player.position - transform.position).normalized;
    // transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    var force = direction * speed;
    _rb2d.velocity = force;
    CheckFlip(player);
  }

  private void CheckFlip(Transform player)
  {
    if (_rb2d.velocity.x > 0)
    {
      //   Flip(-1f);
      transform.localScale = new Vector3(-1f, 1f, 1f);
    }
    else if (_rb2d.velocity.x < 0)
    {
      //   Flip(-1f);
      transform.localScale = new Vector3(1f, 1f, 1f);
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
    }
  }

  void Flip(float scale)
  {
    Vector2 theScale = transform.localScale;
    theScale.x *= scale;
    transform.localScale = theScale;
  }
}