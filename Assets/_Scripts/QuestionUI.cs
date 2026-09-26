using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    public GameManager gameManager;

    public Image itemImage;
    public TMP_Text questionText;
    public TMP_Text questionNumberText;

    public Button[] optionButtons;
    public TMP_Text[] optionTexts;

    public GameObject GamePanel;
    public GameObject resultPanel;
    public TMP_Text finalScoreText;

    private void Start()
    {
        GamePanel.SetActive(true);
        resultPanel.SetActive(false);
    }

    public void ShowQuestion()
    {
        QuestionData question = gameManager.GetCurrentQuestion();

        if (question == null)
        {
            Debug.LogError("No current question found.");
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

    void SelectOption(int optionIndex)
    {
        QuestionData question = gameManager.GetCurrentQuestion();

        if (question == null)
        {
            return;
        }

        int score = question.options[optionIndex].score;

        gameManager.AddScore(score);

        Debug.Log("Selected: " + question.options[optionIndex].optionText);
        Debug.Log("Score: " + score);
        Debug.Log("Total Score: " + gameManager.GetScore());

        gameManager.NextQuestion();

        if (gameManager.HasMoreQuestions())
        {
            ShowQuestion();
        }
        else
        {
            Debug.Log("All questions completed!");
            Debug.Log(gameManager.GetScore() + "/ " + 5 * gameManager.questionsPerGame);

            GamePanel.SetActive(false);
            resultPanel.SetActive(true);
            finalScoreText.text = gameManager.GetScore() + "/ " + 5 * gameManager.questionsPerGame;
        }
    }

    public void RestartGame()
    {
        gameManager.StartGame();
        GamePanel.SetActive(true);
        resultPanel.SetActive(false);
        ShowQuestion();
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}