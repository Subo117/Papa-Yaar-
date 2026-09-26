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

    private void Awake()
    {
        boyFinalPosition = boy.anchoredPosition;
        itemFinalPosition = item.anchoredPosition;
        questionFinalPosition = question.anchoredPosition;

        optionFinalPositions = new Vector2[optionButtons.Length];

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionFinalPositions[i] = optionButtons[i].anchoredPosition;
        }
    }

    public IEnumerator PlayEnterAnimation()
    {
        LeanTween.cancel(boy.gameObject);
        LeanTween.cancel(item.gameObject);
        LeanTween.cancel(question.gameObject);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            LeanTween.cancel(optionButtons[i].gameObject);
        }

        boy.anchoredPosition = new Vector2(900, boyFinalPosition.y);

        item.anchoredPosition = new Vector2(-900, itemFinalPosition.y);

        question.anchoredPosition = new Vector2(900, questionFinalPosition.y);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].anchoredPosition = new Vector2(optionFinalPositions[i].x, -600);
        }

        LeanTween.move(boy, boyFinalPosition, 0.9f).setEaseOutBack();

        yield return new WaitForSeconds(0.25f);

        LeanTween.move(item, itemFinalPosition, 0.9f).setEaseOutBack();

        yield return new WaitForSeconds(0.25f);

        LeanTween.move(question, questionFinalPosition, 0.9f).setEaseOutBack();

        yield return new WaitForSeconds(0.4f);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            LeanTween.move(optionButtons[i], optionFinalPositions[i], 0.7f).setEaseOutBack();

            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator PlayExitAnimation()
    {
        LeanTween.cancel(boy.gameObject);
        LeanTween.cancel(item.gameObject);
        LeanTween.cancel(question.gameObject);

        for (int i = 0; i < optionButtons.Length; i++)
        {
            LeanTween.cancel(optionButtons[i].gameObject);
        }

        for (int i = 0; i < optionButtons.Length; i++)
        {
            LeanTween.move(optionButtons[i], new Vector2(optionFinalPositions[i].x, -600), 0.6f).setEaseInBack();
        }

        yield return new WaitForSeconds(0.25f);


        LeanTween.move(question, new Vector2(900, questionFinalPosition.y), 0.7f).setEaseInBack();

        yield return new WaitForSeconds(0.15f);

        LeanTween.move(item, new Vector2(-900, itemFinalPosition.y), 0.7f).setEaseInBack();

        yield return new WaitForSeconds(0.15f);

        LeanTween.move(boy, new Vector2(900, boyFinalPosition.y), 0.7f).setEaseInBack();

        yield return new WaitForSeconds(0.7f);
    }
}