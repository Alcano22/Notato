using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_AmmoCounter : MonoBehaviour
{
    [SerializeField] Color enabledColor;
    [SerializeField] Color disabledColor;

    public void UpdateAmmo(int ammo)
    {
        for (int i = 0; i < bulletIcons.Length; i++, ammo--)
        {
            SetBulletIconState(bulletIcons[i], ammo > 0);
        }
    }

    void SetBulletIconState(Image icon, bool enabled)
    {
        icon.color = enabled ? enabledColor : disabledColor;
    }

    Image[] bulletIcons => transform.GetComponentsInChildren<Image>();
}
