using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryItem : MonoBehaviour, Item
{
  public void UseItem()
  {
    GameManager.Instance.pickedCherries++;
    Destroy(gameObject);
  }
}
