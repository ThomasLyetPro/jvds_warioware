using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assert = UnityEngine.Assertions.Assert;

public class GameManager : MonoBehaviour
{

  [SerializeField] GameObject minigamesHolder;
  MiniGame[] miniGames;
  [SerializeField] Slider timeSlider;
  [SerializeField] TMP_Text remainingLife;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    Assert.IsNotNull(minigamesHolder);
    miniGames = minigamesHolder.GetComponentsInChildren<MiniGame>();
    foreach (MiniGame miniGame in miniGames)
    {
      miniGame.gameManager = this;
    }
    timeSlider.gameObject.SetActive(false);
    StartCoroutine(StartGame());
  }

  IEnumerator StartGame()
  {
    yield return new WaitForSeconds(2f);
    StartCoroutine(TriggerIntermission(EnterIntermissionState.StartGame));
  }

  public enum EnterIntermissionState { StartGame, Win, Loose }
  int currentLife = 3;
  public IEnumerator TriggerIntermission(EnterIntermissionState state)
  {
    if (currentMinigame)
    {
      currentMinigame.gameObject.SetActive(false);
      currentMinigame = null;
    }
    timeSlider.gameObject.SetActive(false);

    if (state == EnterIntermissionState.Loose)
    {
      currentLife--;
      remainingLife.text = "Life: " + currentLife;
    }

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

  public void TriggerEndOfGame(EnterIntermissionState state)
  {
    StartCoroutine(TriggerIntermission(state));
  }

  MiniGame currentMinigame;
  IEnumerator TriggerMinigame()
  {
    yield return new WaitForSeconds(0f);

    timeSlider.gameObject.SetActive(true);
    timeSlider.value = 1f;

    currentMinigame = miniGames[Random.Range(0, miniGames.Length)];
    currentMinigame.gameObject.SetActive(true);
    currentMinigame.StartMiniGame();
  }

  IEnumerator TriggerEndgame()
  {
    yield return new WaitForSeconds(0f);
    Debug.Log("ENDGAME");
  }

  private void Update()
  {
    if (timeSlider.IsActive())
    {
      timeSlider.value -= Time.deltaTime / 10;
      if (timeSlider.value <= float.Epsilon)
        currentMinigame.TriggerLoose();
    }

  }
}