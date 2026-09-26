using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<QuestionData> questionPool;
    public int questionsPerGame = 10;
    public QuestionUI questionUI;

    private List<QuestionData> selectedQuestions = new List<QuestionData>();

    private int currentQuestionIndex = 0;
    private int jugaduScore = 0;


    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        selectedQuestions.Clear();

        List<QuestionData> shuffledQuestions = new List<QuestionData>(questionPool);

        for (int i = 0; i < shuffledQuestions.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffledQuestions.Count);

            QuestionData temp = shuffledQuestions[i];
            shuffledQuestions[i] = shuffledQuestions[randomIndex];
            shuffledQuestions[randomIndex] = temp;
        }

        int numberOfQuestions = Mathf.Min(questionsPerGame, shuffledQuestions.Count);

        for (int i = 0; i < numberOfQuestions; i++)
        {
            selectedQuestions.Add(shuffledQuestions[i]);
        }

        currentQuestionIndex = 0;
        jugaduScore = 0;

        Debug.Log("Game started with " + selectedQuestions.Count + " questions.");

        questionUI.ShowQuestion();

    }

    public QuestionData GetCurrentQuestion()
    {
        if (currentQuestionIndex >= selectedQuestions.Count)
        {
            return null;
        }

        return selectedQuestions[currentQuestionIndex];
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;
    }

    public void AddScore(int score)
    {
        jugaduScore += score;
    }

    public int GetScore()
    {
        return jugaduScore;
    }

    public int GetQuestionNumber()
    {
        return currentQuestionIndex + 1;
    }

    public bool HasMoreQuestions()
    {
        return currentQuestionIndex < selectedQuestions.Count;
    }
}