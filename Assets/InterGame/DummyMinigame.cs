using UnityEngine;
using UnityEngine.InputSystem;

public class DummyMinigame : MiniGame
{
  public override void StartMiniGame()
  {
    //Nothing to do
  }

  void Update()
  {
    if (Keyboard.current.anyKey.isPressed)
    {
      TriggerWin();
    }
  }
}
