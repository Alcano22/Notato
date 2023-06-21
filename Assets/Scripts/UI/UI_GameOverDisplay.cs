using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GameOverDisplay : UI_MonoBehaviour
{
    public void Show()
    {
        Rect.LeanMoveY(0f, 2f)
            .setEase(LeanTweenType.easeOutBounce);
    }
}
