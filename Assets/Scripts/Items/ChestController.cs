using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

  bool _isEmpty = false;

  public Item item;

  void OnTriggerStay2D(Collider2D col)
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (!_isEmpty)
      {
        OpenChest();
        GiveItemTo(col.gameObject);
      }
      else
      {
        Debug.Log("Chest is empty.");
      }
    }
  }

  void GiveItemTo(GameObject obj)
  {
    Debug.Log("Item given to " + obj.name);
    _isEmpty = true;
  }

  void OpenChest()
  {
    Debug.Log("Chest opened.");
  }
}
