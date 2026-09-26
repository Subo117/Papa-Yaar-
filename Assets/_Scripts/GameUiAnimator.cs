using UnityEngine;
using System.Collections;

public class GameUIAnimator : MonoBehaviour
{
    public RectTransform boy;
    public RectTransform item;
    public RectTransform question;

    public RectTransform[] optionButtons;

    private Vector2 boyFinalPosition;
    private Vector2 itemFinalPosition;
    private Vector2 questionFinalPosition;

    private Vector2[] optionFinalPositions;

    void Awake()
    {
        boyFinalPosition = boy.anchoredPosition;
        itemFinalPosition = item.anchoredPosition;
        questionFinalPosition = question.anchoredPosition;

        optionFinalPositions = new Vector2[optionButtons.Length];

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionFinalPositions[i] = optionButtons[i].anchoredPosition;
        }

        Debug.Log("Position set");
    }

    void Start()
    {
        Debug.Log("Coroutine starting");
        StartCoroutine(PlayIntroAnimation());
    }

    IEnumerator PlayIntroAnimation()
    {
        // Cancel any previous LeanTween animations
        LeanTween.cancel(boy.gameObject);
        LeanTween.cancel(item.gameObject);
        LeanTween.cancel(question.gameObject);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            LeanTween.cancel(optionButtons[i].gameObject);
        }
        Debug.Log("Prev Cancel");

        // Reset everything to its original position first
        boy.anchoredPosition = boyFinalPosition;
        item.anchoredPosition = itemFinalPosition;
        question.anchoredPosition = questionFinalPosition;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].anchoredPosition = optionFinalPositions[i];
        }

        Debug.Log("Reset Original");


        // Move everything to starting positions

        boy.anchoredPosition =
            new Vector2(900, boyFinalPosition.y);

        item.anchoredPosition =
            new Vector2(-900, itemFinalPosition.y);

        question.anchoredPosition =
            new Vector2(900, questionFinalPosition.y);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].anchoredPosition =
                new Vector2(optionFinalPositions[i].x, -600);
        }

        Debug.Log("Starting pos");


        // Boy from right
        LeanTween.move(boy, boyFinalPosition, 0.7f)
            .setEaseOutBack();

        yield return new WaitForSeconds(0.15f);

        // Item from left
        LeanTween.move(item, itemFinalPosition, 0.7f)
            .setEaseOutBack();

        yield return new WaitForSeconds(0.15f);

        // Question from right
        LeanTween.move(question, questionFinalPosition, 0.7f)
            .setEaseOutBack();

        yield return new WaitForSeconds(0.3f);

        // Options from bottom
        for (int i = 0; i < optionButtons.Length; i++)
        {
            LeanTween.move(
                optionButtons[i],
                optionFinalPositions[i],
                0.5f
            ).setEaseOutBack();

            yield return new WaitForSeconds(0.12f);
        }

        Debug.Log("Animations");

    }
}