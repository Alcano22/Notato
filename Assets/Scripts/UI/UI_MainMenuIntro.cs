using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenuIntro : MonoBehaviour
{
    [SerializeField] RectTransform background;
    [SerializeField] CanvasGroup studioPopup;

    void Start()
    {
        studioPopup.LeanAlpha(1f, 1f)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => LeanTween.delayedCall(3f, () =>
            {
                studioPopup.LeanAlpha(0f, 1f)
                    .setEase(LeanTweenType.easeInOutSine);
                background.LeanAlpha(0f, 1f)
                    .setEase(LeanTweenType.easeInOutSine);
            }));
    }
}
