using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Player")
    {
      GameManager.Instance.pickedCherries += 1;
      Destroy(gameObject);
    }
  }

}
