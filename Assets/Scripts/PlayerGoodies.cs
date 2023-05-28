using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerGoodies : MonoBehaviour
{


    
    // Start is called before the first frame update

    private static int maxkills;
    public static int kills;
    public static int coins { get; set; }
    public static int getMaxKills()
    {
        return maxkills;
    }
    public  int getKills()
    {
        return kills;
    }
    public int getCoins()
    {
        return coins;
    }
    public static void setMaxKills(int newmax)
    {
        if(maxkills<newmax)
        maxkills = newmax;
    }
    
    public static void setKills(int currentkills)
    {
        kills= currentkills;
    }
    public static void updatekills(int kill)
    {
        kills += kill;
    }
    public static void setCoins(int currentAmount)
    {
        coins= currentAmount;
    }
    public static void UpdateCoins(int recievedCoins)
    {
        coins += recievedCoins;
    }
    private void Start()
    {
        kills = 0;
        maxkills = PlayerPrefs.GetInt("maxkills");
        if (PlayerPrefs.GetInt("coins") <= 40)
        {
            int x = Random.Range(80,100);
            PlayerPrefs.SetInt("coins",x);
        }
        coins = PlayerPrefs.GetInt("coins");
        print(coins);
        print("Playerprefs :"+PlayerPrefs.GetInt("coins"));
    }

    // Update is called once per frame


}
