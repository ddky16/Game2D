using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
  public CharacterStats characterStats;
  public int health;
  public bool isPlayer2;
  public string enemyName;

  [HideInInspector]
  public Animator _animator;
  private Collider2D _collider;

  [HideInInspector]
  public bool isIdling = true;
  [HideInInspector]
  public bool isWalking = false;
  [HideInInspector]
  public bool isAttack = false;

  // Start is called before the first frame update
  void Start()
  {
    isIdling = true;
    isWalking = false;
    isAttack = false;

    health = characterStats.GetHealth;
    _animator = GetComponent<Animator>();
    _collider = GetComponentInChildren<Collider2D>();
    StartCoroutine(Idling());
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (isIdling)
    {
      _animator.Play("Idle");
    }
    else if (isWalking)
    {
      Moving();
    }
  }

  private void Moving()
  {
    if (!isIdling && !isPlayer2)
    {
      transform.position += transform.right * characterStats.GetMovementSpeed * Time.deltaTime;
      _animator.Play("Walking");
    }
    else if (!isIdling && isPlayer2)
    {
      transform.position += -transform.right * characterStats.GetMovementSpeed * Time.deltaTime;
      _animator.Play("Walking");
    }
  }

  IEnumerator Idling()
  {
    _animator.Play("Idle");
    yield return new WaitForSeconds(2);
    isIdling = false;
    isWalking = true;
  }
}
