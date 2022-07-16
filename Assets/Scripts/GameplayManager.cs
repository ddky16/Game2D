using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
  public HealthBarScript[] healthBarScript;
  private CountdownController _countdownController;

  [Header("Gameplay CountDown")]
  public TMP_Text countdownTxt;

  [Header("Panel UI")]
  public GameObject panelCountDown;
  public GameObject panelPlayer1;
  public GameObject panelPlayer2;
  public GameObject panelWinner;
  public TMP_Text winnersTxt;

  [Header("Character Manager")]
  public GameObject minotaurPrefab;
  GameObject minotaur;
  public GameObject wraithPrefab;
  GameObject wraith;
  public Transform characterContainerSpawn;

  private bool _isDone = false;

  // Start is called before the first frame update
  void Start()
  {
    _countdownController = GetComponent<CountdownController>();
  }

  // Update is called once per frame
  void Update()
  {
    countdownTxt.text = ((int)_countdownController.GetCurrentCount).ToString();

    if (_countdownController.GetCurrentCount <= 0 && !_isDone)
    {
      panelCountDown.SetActive(false);
      panelPlayer1.SetActive(true);
      panelPlayer2.SetActive(true);

      SetCharacterSpawn();
      _isDone = true;
    }

    if (_countdownController.GetCurrentCount <= 1)
    {
      if (healthBarScript[0].currentHealth <= 0)
      {
        panelWinner.SetActive(true);
        winnersTxt.text = string.Format("Winners: {0}", wraith.GetComponent<CharacterManager>().characterStats.CharacterName);
        wraith.GetComponent<CharacterManager>().isIdling = true;
        minotaur.GetComponent<CharacterManager>().isIdling = true;
      }
      else if (healthBarScript[1].currentHealth <= 0)
      {
        panelWinner.SetActive(true);
        winnersTxt.text = string.Format("Winners: {0}", minotaur.GetComponent<CharacterManager>().characterStats.CharacterName);
        wraith.GetComponent<CharacterManager>().isIdling = true;
        minotaur.GetComponent<CharacterManager>().isIdling = true;
      }
    }
  }

  void SetCharacterSpawn()
  {
    minotaur = Instantiate(minotaurPrefab, new Vector3(-13, 0, 0), Quaternion.identity, characterContainerSpawn);
    minotaur.name = "Minotaur";

    wraith = Instantiate(wraithPrefab, new Vector3(13, -1, 0), Quaternion.identity, characterContainerSpawn);
    wraith.name = "Wraith";
  }
}
