using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumShopUI : MonoBehaviour
{
    public RectTransform cymbalButton;
    public RectTransform kitButton;

    public float animationTime = 0.25f;

    public float hiddenX;
    public float shownX;

    private bool isOpen = false;

    public void ToggleShop()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateButtons(!isOpen));
        isOpen = !isOpen;
    }

    IEnumerator AnimateButtons(bool show)
    {
        float time = 0f;

        Vector2 cymbalStart = cymbalButton.anchoredPosition;
        Vector2 kitStart = kitButton.anchoredPosition;

        Vector2 cymbalEnd = new Vector2(show ? shownX : hiddenX, cymbalStart.y);
        Vector2 kitEnd = new Vector2(show ? shownX : hiddenX, kitStart.y);

        while (time < animationTime)
        {
            time += Time.deltaTime;
            float t = time / animationTime;

            cymbalButton.anchoredPosition = Vector2.Lerp(cymbalStart, cymbalEnd, t);
            kitButton.anchoredPosition = Vector2.Lerp(kitStart, kitEnd, t);

            yield return null;
        }

        cymbalButton.anchoredPosition = cymbalEnd;
        kitButton.anchoredPosition = kitEnd;
    }

}
