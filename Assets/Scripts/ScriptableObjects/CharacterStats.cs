using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Characters/CharacterStats", order = 0)]
public class CharacterStats : ScriptableObject
{
  [SerializeField]
  public string _charName;
  [SerializeField]
  private int _health;
  [SerializeField]
  private int _attackPower;
  [SerializeField]
  private float _attackRateDelay;
  [SerializeField]
  private float _movementSpeed;

  public string CharacterName { get { return _charName; } }
  public int GetHealth { get { return _health; } }
  public int GetAttackPower { get { return _attackPower; } }
  public float GetAttackRate { get { return _attackRateDelay; } }
  public float GetMovementSpeed { get { return _movementSpeed; } }
}

