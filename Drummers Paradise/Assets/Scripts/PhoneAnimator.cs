using UnityEngine;
using System.Collections;

public class PhoneAnimator : MonoBehaviour
{
    [Header("References")]
    public RectTransform phoneTransform;   
    public CanvasGroup canvasGroup;        

    [Header("Animation Settings")]
    public float animationTime = 0.25f;

    [Header("Positions")]
    public float hiddenX = 150f;
    public float hiddenY = -600f;

    public float shownX = 150f;
    public float shownY = 150f;

    private bool isOpen = false;
    private Coroutine currentAnim;

    void Start()
    {
        
        phoneTransform.anchoredPosition = new Vector2(hiddenX, hiddenY);

        canvasGroup.alpha = 0.8f;
    }

    public void TogglePhone()
    {

        isOpen = !isOpen;

        if (currentAnim != null)
            StopCoroutine(currentAnim);

        currentAnim = StartCoroutine(AnimatePhone(isOpen));
    }

    IEnumerator AnimatePhone(bool open)
    {
        float time = 0f;

        Vector2 startPos = phoneTransform.anchoredPosition;
        float startAlpha = canvasGroup.alpha;

        Vector2 targetPos = open
            ? new Vector2(shownX, shownY)
            : new Vector2(hiddenX, hiddenY);

        float targetAlpha = open ? 1f : 0.8f;

        while (time < animationTime)
        {
            time += Time.deltaTime;

            float t = Mathf.SmoothStep(0f, 1f, time / animationTime);

            phoneTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);

            yield return null;
        }

        phoneTransform.anchoredPosition = targetPos;
        canvasGroup.alpha = targetAlpha;
    }
}