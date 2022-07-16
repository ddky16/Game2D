using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
  CharacterManager _characterManager;

  private void Start()
  {
    _characterManager = GetComponentInParent<CharacterManager>();
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.name == "Minotaur")
    {
      other.gameObject.GetComponent<CharacterManager>().health -= _characterManager.characterStats.GetAttackPower;
      Destroy(gameObject, 0f);
    }
  }
}
