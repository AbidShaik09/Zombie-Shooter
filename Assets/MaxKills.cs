using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxKills : MonoBehaviour
{
    TextMeshProUGUI maxKillsText;

    private void Start()
    {
        maxKillsText=GetComponent<TextMeshProUGUI>();

    }
    private void Update()
    {
        maxKillsText.text = "Max Kills: " + PlayerPrefs.GetInt("maxkills");
    }
}
