using System.Collections;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

public class GameManager : MonoBehaviour
{

  [SerializeField] GameObject minigamesHolder;
  MiniGame[] miniGames;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    Assert.IsNotNull(minigamesHolder);
    miniGames = minigamesHolder.GetComponentsInChildren<MiniGame>();
    StartCoroutine(StartGame());
  }

  IEnumerator StartGame()
  {
    yield return new WaitForSeconds(2f);
    StartCoroutine(TriggerIntermission());
  }

  int currentLife = 3;
  IEnumerator TriggerIntermission()
  {
    if (currentLife <= 0)
    {
      yield return TriggerEndgame();
    }
    else
    {
      yield return new WaitForSeconds(2f);
      StartCoroutine(TriggerMinigame());
    }
  }

  MiniGame currentMinigame;
  IEnumerator TriggerMinigame()
  {
    yield return new WaitForSeconds(0f);
    currentMinigame = miniGames[Random.Range(0, miniGames.Length)];
    currentMinigame.StartMiniGame();
  }

  IEnumerator TriggerEndgame()
  {
    yield return new WaitForSeconds(0f);
    Debug.Log("ENDGAME");
  }

}