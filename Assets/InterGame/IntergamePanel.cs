using System;
using UnityEngine;

public class IntergamePanel : MonoBehaviour
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
