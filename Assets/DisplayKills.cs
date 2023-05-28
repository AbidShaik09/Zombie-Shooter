using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class DisplayKills : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI killsdisplay; 
    [SerializeField] TextMeshProUGUI GrenadesDisplay;
    [SerializeField] TextMeshProUGUI HealthDisplay;
    [SerializeField] TextMeshProUGUI coinsdisplay;
    [SerializeField] PlayerGoodies m_PlayerGoodies;
    void Start()
    {
        m_PlayerGoodies = FindAnyObjectByType<PlayerGoodies>();
        killsdisplay=GetComponent<TextMeshProUGUI>();

        coinsdisplay.text = "Coins: " + m_PlayerGoodies.getCoins();
        //m_TextMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        killsdisplay.text = "Kills: " + m_PlayerGoodies.getKills();
        coinsdisplay.text = "Coins: " + m_PlayerGoodies.getCoins();
        GrenadesDisplay.text = ""+PlayerControllerScript.GrenadeCount;
        HealthDisplay.text = "" + PlayerControllerScript.HealCount;
    }
}
