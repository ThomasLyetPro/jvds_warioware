using TMPro;
using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
  private GameManager _gameManager;
  public GameManager gameManager { set => _gameManager = value; }

  bool isBeingPlayed = false;

  protected void TriggerWin()
  {
    isBeingPlayed = false;
    _gameManager.TriggerEndOfMiniGame(GameManager.EnterIntergameState.Win);
  }

  public void TriggerLoose()
  {
    isBeingPlayed = false;
    _gameManager.TriggerEndOfMiniGame(GameManager.EnterIntergameState.Loose);
  }

  private float timer = 8f;
  private float currentTimer = 0f;
  private void Update()
  {
    if (!isBeingPlayed) return;
    currentTimer += Time.deltaTime;
    if (currentTimer >= timer)
      TriggerLoose();
  }

  public abstract void StartMiniGame();
  public void TriggerStartMiniGame()
  {
    currentTimer = 0f;
    StartMiniGame();
  }
}
