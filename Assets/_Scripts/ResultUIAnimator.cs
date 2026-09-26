using UnityEngine;
using System.Collections;

public class ResultUIAnimator : MonoBehaviour
{
    public RectTransform finalScoreText;
    public RectTransform scoreText;

    public RectTransform replayButton;
    public RectTransform mainMenuButton;

    private Vector2 finalScoreFinalPosition;
    private Vector2 scoreFinalPosition;
    private Vector2 replayFinalPosition;
    private Vector2 mainMenuFinalPosition;

    private void Awake()
    {
        finalScoreFinalPosition = finalScoreText.anchoredPosition;

        scoreFinalPosition = scoreText.anchoredPosition;

        replayFinalPosition = replayButton.anchoredPosition;

        mainMenuFinalPosition = mainMenuButton.anchoredPosition;

        finalScoreText.anchoredPosition = new Vector2(finalScoreFinalPosition.x, 700);

        scoreText.anchoredPosition = new Vector2(scoreFinalPosition.x, 700);

        replayButton.anchoredPosition = new Vector2(-1500, replayFinalPosition.y);

        mainMenuButton.anchoredPosition = new Vector2(1500, mainMenuFinalPosition.y);
    }

    public IEnumerator PlayResultAnimation()
    {
        LeanTween.cancel(finalScoreText.gameObject);
        LeanTween.cancel(scoreText.gameObject);
        LeanTween.cancel(replayButton.gameObject);
        LeanTween.cancel(mainMenuButton.gameObject);

        LeanTween.move(finalScoreText, finalScoreFinalPosition, 0.9f).setEaseOutBack();

        yield return new WaitForSeconds(0.2f);

        LeanTween.move(scoreText, scoreFinalPosition, 0.9f).setEaseOutBack();

        yield return new WaitForSeconds(0.35f);

        LeanTween.move(replayButton, replayFinalPosition, 0.8f).setEaseOutBack();

        yield return new WaitForSeconds(0.2f);

        LeanTween.move(mainMenuButton, mainMenuFinalPosition, 0.8f).setEaseOutBack();

        yield return new WaitForSeconds(0.8f);
    }
}