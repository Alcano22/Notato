using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MonoBehaviour : MonoBehaviour
{
    void Awake()
    {
        if (transform is RectTransform) return;

        Debug.LogError("Components that inherit from UI_MonoBehaviour cannot be used by non-UI objects");
        enabled = false;
    }

    public RectTransform Rect => (RectTransform)transform;
}
