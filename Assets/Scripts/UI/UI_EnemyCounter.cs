using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_EnemyCounter : MonoBehaviour
{
    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdateEnemyCount(int numEnemies)
    {
        text.text = numEnemies + " Enemies left";
    }
}
