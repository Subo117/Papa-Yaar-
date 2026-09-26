using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class QuestionUI : MonoBehaviour
{
    public GameManager gameManager;
    public GameUIAnimator gameUIAnimator;
    public ResultUIAnimator resultUIAnimator;

    public Image itemImage;
    public TMP_Text questionText;
    public TMP_Text questionNumberText;

    public Button[] optionButtons;
    public TMP_Text[] optionTexts;

    public GameObject GamePanel;
    public GameObject resultPanel;
    public GameObject pausePanel;
    public TMP_Text finalScoreText;

    private bool isAnimating = false;

    private void Start()
    {
        GamePanel.SetActive(true);
        resultPanel.SetActive(false);
        pausePanel.SetActive(false);

        gameManager.StartGame();

        StartCoroutine(RestartAnimation());
    }

    public void ShowQuestion()
    {
        QuestionData question = gameManager.GetCurrentQuestion();

        if (question == null)
        {
            return;
        }

        itemImage.sprite = question.itemImage;
        questionText.text = question.questionText;

        questionNumberText.text = gameManager.GetQuestionNumber() + " / " + gameManager.questionsPerGame;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int optionIndex = i;

            optionTexts[i].text = question.options[i].optionText;

            optionButtons[i].onClick.RemoveAllListeners();

            optionButtons[i].onClick.AddListener(() =>
            {
                SelectOption(optionIndex);
            });
        }
    }

    public void PlayFirstQuestion()
    {
        ShowQuestion();

        StartCoroutine(EnterQuestion());
    }

    IEnumerator EnterQuestion()
    {
        isAnimating = true;

        SetButtonsInteractable(false);

        yield return StartCoroutine(gameUIAnimator.PlayEnterAnimation());

        SetButtonsInteractable(true);

        isAnimating = false;
    }

    void SelectOption(int optionIndex)
    {
        if (isAnimating)
        {
            return;
        }
        AudioManager.Instance.PlayAudio();

        StartCoroutine(ProcessAnswer(optionIndex));
    }

    IEnumerator ProcessAnswer(int optionIndex)
    {
        isAnimating = true;

        SetButtonsInteractable(false);

        QuestionData question = gameManager.GetCurrentQuestion();

        if (question == null)
        {
            yield break;
        }

        int score = question.options[optionIndex].score;

        gameManager.AddScore(score);

        yield return StartCoroutine(gameUIAnimator.PlayExitAnimation());

        yield return new WaitForSeconds(0.5f);

        gameManager.NextQuestion();

        if (gameManager.HasMoreQuestions())
        {
            ShowQuestion();

            yield return StartCoroutine(gameUIAnimator.PlayEnterAnimation());

            SetButtonsInteractable(true);

            isAnimating = false;
        }
        else
        {
            GamePanel.SetActive(false);
            resultPanel.SetActive(true);

            finalScoreText.text = gameManager.GetScore() + " / " + 5 * gameManager.questionsPerGame;

            yield return new WaitForSeconds(0.2f);

            yield return StartCoroutine(resultUIAnimator.PlayResultAnimation());

            isAnimating = false;
        }
    }

    void SetButtonsInteractable(bool value)
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].interactable = value;
        }
    }

    public void RestartGame()
    {
        AudioManager.Instance.PlayAudio();

        GamePanel.SetActive(true);
        resultPanel.SetActive(false);

        gameManager.StartGame();

        StartCoroutine(RestartAnimation());
    }

    IEnumerator RestartAnimation()
    {
        isAnimating = true;

        SetButtonsInteractable(false);

        yield return new WaitForSeconds(0.3f);

        ShowQuestion();

        yield return StartCoroutine(gameUIAnimator.PlayEnterAnimation());

        SetButtonsInteractable(true);

        isAnimating = false;
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlayAudio();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void PauseGame()
    {
        AudioManager.Instance.PlayAudio();

        GamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        AudioManager.Instance.PlayAudio();

        pausePanel.SetActive(false);
        GamePanel.SetActive(true);
    }
}