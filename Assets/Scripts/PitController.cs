using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.name == "Player")
    {
      collider.transform.position = collider.GetComponent<PlayerController>().startPosition;
      collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      if (GameManager.Instance.currentHealth > 0)
      {
        GameManager.Instance.currentHealth--;
      }
    }
    if (collider.gameObject.tag == "Enemy")
    {
      Destroy(collider.gameObject);
    }
  }

}
