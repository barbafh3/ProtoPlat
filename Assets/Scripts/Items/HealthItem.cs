using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, Item
{

  public void UseItem()
  {
    GameManager.Instance.currentHealth++;
    Destroy(gameObject);
  }

}
