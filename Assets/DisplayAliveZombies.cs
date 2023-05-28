using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayAliveZombies : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Alive: "+ZombieSpawnScript.ZombieCount;
    }
}
