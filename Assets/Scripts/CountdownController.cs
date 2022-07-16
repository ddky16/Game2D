using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownController : MonoBehaviour
{
  private float _currentCountdown = 3f;

  // Update is called once per frame
  void Update()
  {
    _currentCountdown -= Time.deltaTime;
  }

  public float GetCurrentCount { get { return _currentCountdown; } }
}
