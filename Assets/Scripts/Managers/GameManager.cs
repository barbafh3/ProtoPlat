using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

  public int pickedCherries = 0;

  float _defaultHealth = 3f;

  public float currentHealth = 0f;

  private static GameManager _instance;

  public static GameManager Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<GameManager>();
        if (_instance == null)
        {
          var obj = new GameObject();
          obj.name = typeof(GameManager).Name;
          _instance = obj.AddComponent<GameManager>();
        }
      }
      return _instance;
    }
  }

  void Awake()
  {
    if (_instance != this && _instance != null)
    {
      Destroy(gameObject);
    }
    _instance = this;
    currentHealth = _defaultHealth;
  }

  void OnDisable()
  {
    _instance = null;
  }

}
