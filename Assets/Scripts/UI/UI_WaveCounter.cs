using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_WaveCounter : UI_MonoBehaviour
{
    [SerializeField] RectTransform hordeWaveText;

    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdateWave(Wave wave, Game game)
    {
        text.text = "Wave " + wave.Index.ToString();

        WaveTitleIn(wave, game);
    }

    void WaveTitleIn(Wave wave, Game game)
    {
        Rect.LeanMoveY(-300f, 1f)
            .setEase(LeanTweenType.easeInOutSine);
        Rect.LeanSize(new Vector2(500f, 150f), 1f)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => LeanTween.delayedCall(1f, () =>
            {
                if (wave.HordeWave)
                {
                    HordeWaveInOut(wave, game);
                    return;
                }

                WaveTitleOut(wave);
            }));
    }

    void HordeWaveInOut(Wave wave, Game game)
    {
        hordeWaveText.LeanMoveX(0f, .5f)
            .setEase(LeanTweenType.easeOutExpo)
            .setOnComplete(() => LeanTween.delayedCall(1f, () =>
            {
                hordeWaveText.LeanMoveX(1110f, .5f)
                    .setEase(LeanTweenType.easeInExpo)
                    .setOnComplete(() => LeanTween.delayedCall(1f, () =>
                    {
                        ResetHordeWaveTextPosition();
                        WaveTitleOut(wave);
                    }));
            }));
    }

    void WaveTitleOut(Wave wave)
    {
        Rect.LeanMoveY(-50f, 1f)
                .setEase(LeanTweenType.easeInOutSine);
        Rect.LeanSize(new Vector2(150f, 50f), 1f)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => LeanTween.delayedCall(1f, wave.Start));
    }

    void ResetHordeWaveTextPosition()
    {
        Vector2 pos = hordeWaveText.position;
        pos.x = -1110f;
        hordeWaveText.position = pos;
    }
}
