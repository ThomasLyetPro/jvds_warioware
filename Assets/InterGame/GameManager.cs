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
  [SerializeField] StartPanel startPanel;
  [SerializeField] IntergamePanel intergamePanel;
  [SerializeField] GameOverPanel gameOverPanel;


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
    startPanel.Begin();
    yield return new WaitForSeconds(2f);
    startPanel.End();
    StartCoroutine(TriggerIntergame(EnterIntergameState.StartGame));
  }

  public enum EnterIntergameState { StartGame, Win, Loose }
  int currentLife = 3;
  public IEnumerator TriggerIntergame(EnterIntergameState state)
  {
    if (currentMinigame)
    {
      currentMinigame.gameObject.SetActive(false);
      currentMinigame = null;
    }
    timeSlider.gameObject.SetActive(false);

    if (state == EnterIntergameState.Loose)
    {
      currentLife--;
      remainingLife.text = "Life: " + currentLife;
    }

    if (currentLife <= 0)
    {
      TriggerEndgame();
    }
    else
    {
      intergamePanel.Begin();
      yield return new WaitForSeconds(2f);
      intergamePanel.End();
      TriggerMinigame();
    }
  }

  public void TriggerEndOfMiniGame(EnterIntergameState state)
  {
    StartCoroutine(TriggerIntergame(state));
  }

  MiniGame currentMinigame;
  void TriggerMinigame()
  {
    timeSlider.gameObject.SetActive(true);
    timeSlider.value = 1f;

    currentMinigame = miniGames[Random.Range(0, miniGames.Length)];
    currentMinigame.gameObject.SetActive(true);
    currentMinigame.StartMiniGame();
  }

  void TriggerEndgame()
  {
    gameOverPanel.Begin();
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