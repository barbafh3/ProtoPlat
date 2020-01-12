using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

  public TextMeshProUGUI cherryNumberText = null;

  public TextMeshProUGUI healthText = null;

  private static UIManager _instance;

  public static UIManager Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<UIManager>();
        if (_instance == null)
        {
          var obj = new GameObject();
          obj.name = typeof(UIManager).Name;
          _instance = obj.AddComponent<UIManager>();
        }
      }
      return _instance;
    }
  }

  void OnDisable()
  {
    _instance = null;
  }

  void Awake()
  {
    if (_instance != this && _instance != null)
    {
      Destroy(gameObject);
    }
    _instance = this;
    cherryNumberText.text = "x 0";
  }

  void Update()
  {
    cherryNumberText.text = "x " + GameManager.Instance.pickedCherries;
    healthText.text = "x " + GameManager.Instance.currentHealth;
  }
}
