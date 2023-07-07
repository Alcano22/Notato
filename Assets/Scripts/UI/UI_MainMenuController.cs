using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenuController : MonoBehaviour
{
    static readonly Vector2Int CAM_OFFSET = new Vector2Int(-1920, -1080);
    static readonly Vector2Int MAIN_MENU_SECTION_POSITION = new Vector2Int(0, 0);
    static readonly Vector2Int SETTINGS_SECTION_POSITION = new Vector2Int(1, 0);
    static readonly Vector2Int CREDITS_SECTION_POSITION = new Vector2Int(0, -1);

    [SerializeField] float smoothTime;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void SwitchSection(Vector2Int sectionPosition)
    {
        gameObject.LeanMoveLocal((Vector2)(sectionPosition * CAM_OFFSET), smoothTime)
            .setEase(LeanTweenType.easeInOutSine);
    }

    public void SwitchSection(int x, int y)
    {
        SwitchSection(new Vector2Int(x, y));
    }

    public void SwitchToMainMenuSection()
    {
        SwitchSection(MAIN_MENU_SECTION_POSITION);
    }

    public void SwitchToSettingsSection()
    {
        SwitchSection(SETTINGS_SECTION_POSITION);
    }

    public void SwitchToCreditsSection()
    {
        SwitchSection(CREDITS_SECTION_POSITION);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SwitchToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SwitchToRickrollScene()
    {
        SceneManager.LoadScene(2);
    }
}
