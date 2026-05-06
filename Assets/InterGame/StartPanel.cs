using System;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
  internal void Begin()
  {
    gameObject.SetActive(true);
  }

  internal void End()
  {
    gameObject.SetActive(false);
  }

}
