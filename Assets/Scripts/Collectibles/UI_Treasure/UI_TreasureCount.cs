using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TreasureCount : MonoBehaviour
{
    TextMeshProUGUI treasureUI;

    private void Awake()
    {
        treasureUI = GetComponent<TextMeshProUGUI>();

        treasureUI.SetText("Treasure: 0");
    }

    public void updateUIText(TankController tankController)
    {
        treasureUI.SetText("Treasure: " + tankController.TreasureCount);
    }
}
