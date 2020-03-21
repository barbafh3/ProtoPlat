using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

  public bool[] isFull;

  public GameObject[] slots;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      if (isFull[0] == true)
      {
        slots[0].GetComponentInChildren<Item>().UseItem();
        isFull[0] = false;
      }
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      if (isFull[1] == true)
      {
        slots[1].GetComponentInChildren<Item>().UseItem();
        isFull[1] = false;
      }
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      if (isFull[2] == true)
      {
        slots[2].GetComponentInChildren<Item>().UseItem();
        isFull[2] = false;
      }
    }
  }

}
