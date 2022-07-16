using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
  private CharacterManager _parentComponent;
  public GameObject spellPrefab;
  public Transform spellPoint;
  GameObject enemy;

  private void Start()
  {
    _parentComponent = GetComponentInParent<CharacterManager>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Enemy"))
    {
      enemy = other.gameObject;
      _parentComponent.isAttack = true;
      _parentComponent.isWalking = false;
      StartCoroutine(Attacking());
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    _parentComponent.isAttack = false;
  }

  IEnumerator Attacking()
  {
    while (true)
    {
      _parentComponent.isIdling = true;

      yield return new WaitForSeconds(_parentComponent.characterStats.GetAttackRate);

      _parentComponent.isIdling = false;
      _parentComponent._animator.Play("Attack");

      yield return new WaitForSeconds(1);

      if (_parentComponent.isPlayer2)
      {
        GameObject spell = Instantiate(spellPrefab, spellPoint.position, spellPoint.rotation, spellPoint);
        spell.name = "Spell";
        Rigidbody2D rbSpell = spell.GetComponent<Rigidbody2D>();
        rbSpell.velocity = transform.right * _parentComponent.characterStats.GetMovementSpeed * -3 * Time.deltaTime;

        Destroy(spell, 2);
      }
      else
      {
        var hit = _parentComponent.characterStats.GetAttackPower;
        enemy.GetComponentInParent<CharacterManager>().health -= hit;
      }

      if (!_parentComponent.isAttack)
      {
        _parentComponent.isWalking = true;
        yield break;
      }
    }
  }
}
