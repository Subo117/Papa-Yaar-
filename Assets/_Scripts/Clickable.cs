using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    [SerializeField] private float alphaThreshold = 0.1f;

    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaThreshold;
    }


}
