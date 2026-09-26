using UnityEngine;
using System.Collections;

public class MainMenuAnimator : MonoBehaviour
{
    public RectTransform gameName;
    public RectTransform playButton;
    public RectTransform quitButton;
    public RectTransform boy;

    private Vector2 gameNameFinalPosition;
    private Vector2 playFinalPosition;
    private Vector2 quitFinalPosition;
    private Vector2 boyFinalPosition;

    private Vector3 gameNameFinalScale;

    private void Awake()
    {
        gameNameFinalPosition =
            gameName.anchoredPosition;

        playFinalPosition =
            playButton.anchoredPosition;

        quitFinalPosition =
            quitButton.anchoredPosition;

        boyFinalPosition =
            boy.anchoredPosition;

        gameNameFinalScale =
            gameName.localScale;


        gameName.anchoredPosition =
            new Vector2(
                -1500,
                gameNameFinalPosition.y
            );

        playButton.anchoredPosition =
            new Vector2(
                -1500,
                playFinalPosition.y
            );

        quitButton.anchoredPosition =
            new Vector2(
                quitFinalPosition.x,
                -700
            );

        boy.anchoredPosition =
            new Vector2(
                1500,
                boyFinalPosition.y
            );
    }

    private void Start()
    {
        StartCoroutine(PlayMenuAnimation());
    }

    IEnumerator PlayMenuAnimation()
    {
        // Game Name

        LeanTween.move(
            gameName,
            gameNameFinalPosition,
            0.9f
        ).setEaseOutBack();

        yield return new WaitForSeconds(0.25f);

        // Boy

        LeanTween.move(
            boy,
            boyFinalPosition,
            0.9f
        ).setEaseOutBack();

        yield return new WaitForSeconds(0.25f);

        // Play Button

        LeanTween.move(
            playButton,
            playFinalPosition,
            0.8f
        ).setEaseOutBack();

        yield return new WaitForSeconds(0.2f);

        // Quit Button

        LeanTween.move(
            quitButton,
            quitFinalPosition,
            0.8f
        ).setEaseOutBack();

        yield return new WaitForSeconds(0.8f);

        // Start breathing animation

        StartBreathingAnimation();
    }

    void StartBreathingAnimation()
    {
        gameName.localScale = gameNameFinalScale;

        LeanTween.scale(
            gameName.gameObject,
            gameNameFinalScale * 1.06f,
            1.2f
        )
        .setEaseInOutSine()
        .setLoopPingPong();
    }
}