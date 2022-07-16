using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
  public static SceneHandler _instance;

  public void LobbyScene()
  {
    SceneManager.LoadScene("Lobby Scene");
  }

  public void GameplayScene()
  {
    SceneManager.LoadScene("Gameplay Scene");
  }
}
