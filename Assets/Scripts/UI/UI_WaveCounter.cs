using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_WaveCounter : UI_MonoBehaviour
{
    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdateWave(float wave, Game game)
    {
        text.text = "Wave " + wave.ToString();

        Rect.LeanMoveY(-300f, 1f)
            .setEase(LeanTweenType.easeInOutSine);
        Rect.LeanSize(new Vector2(500f, 150f), 1f)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => LeanTween.delayedCall(3f, () =>
        {
            Rect.LeanMoveY(-50f, 1f)
                .setEase(LeanTweenType.easeInOutSine);
            Rect.LeanSize(new Vector2(150f, 50f), 1f)
                .setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => LeanTween.delayedCall(1f, () => game.OnWaveStart()));
        }));
    }
}
