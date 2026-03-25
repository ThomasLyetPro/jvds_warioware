using TMPro;
using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
  private GameManager _gameManger;
  public GameManager gameManger { set => _gameManger = value; }

  bool isBeingPlayed = false;

  protected void TriggerWin()
  {
    isBeingPlayed = false;
  }

  protected void TriggerLoose()
  {
    isBeingPlayed = false;
  }

  private float timer = 10f;
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
