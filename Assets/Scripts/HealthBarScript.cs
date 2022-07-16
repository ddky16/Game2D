using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
  public string characterName;
  private GameObject _characterObject;

  private Image _healthBar;
  public float currentHealth;
  private float _maxHealth;

  // Start is called before the first frame update
  void Start()
  {
    _healthBar = GetComponent<Image>();
    _characterObject = GameObject.Find(characterName);

    _maxHealth = _characterObject.GetComponent<CharacterManager>().characterStats.GetHealth;
  }

  // Update is called once per frame
  void Update()
  {
    currentHealth = _characterObject.GetComponent<CharacterManager>().health;

    _healthBar.fillAmount = currentHealth / _maxHealth;
  }
}
