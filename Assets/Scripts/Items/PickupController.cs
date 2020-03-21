using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

  public GameObject itemButton;

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.CompareTag("Player"))
    {
      var inventory = col.GetComponent<InventoryController>();
      for (var i = 0; i < inventory.slots.Length; i++)
      {
        if (inventory.isFull[i] == false)
        {
          inventory.isFull[i] = true;
          Instantiate(itemButton, inventory.slots[i].transform, false);
          Destroy(gameObject);
          break;
        }
      }
    }
  }

}
