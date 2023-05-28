using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gunpanel;
    public static GameObject gunspan;
    public Sprite[] guns;
    public static Sprite[] Guns;
    public int[] gunCost;
    public int[] ammoSet;
    public int[] maxammoSet;
    public static int cugun;
    public static int[] GunCost;
    public static int[] AmmoSet;
    public static int[] MaxAmmoSet;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI price;
    public TextMeshProUGUI bullets;
    public TextMeshProUGUI bulletprice;
    public static TextMeshProUGUI Price;
    public static TextMeshProUGUI Coins;
    public static TextMeshProUGUI Bullets;
    public static TextMeshProUGUI Bulletprice;
    // public static int cash;
    void Start()
    {
        MaxAmmoSet = maxammoSet;
        AmmoSet = ammoSet;
        Price = price;
        Bullets= bullets;
        Coins = coins;
        Bulletprice = bulletprice;
        try
        {
            coins.text = "Coins : " + PlayerGoodies.coins;
        }
        catch (Exception )
        {
            coins.text = "invalid";
        }
            // cash = PlayerGoodies.coins;
        gunspan = gunpanel;
        GunCost = new int[gunCost.Length];
        Guns= new Sprite[guns.Length];
        for(int i = 0; i < guns.Length; i++)
        {
            Guns[i] = guns[i];
            GunCost[i] = gunCost[i];
        }
        cugun = 0;
        if (!PlayerControllerScript.Gunsowned[cugun])
        {
            Price.text = "Price: " + GunCost[cugun];
            Price.enabled = true;
        }
        else
        {
            Price.text = "Owned";
            
        }
        gunpanel.GetComponent < Image > ().sprite=Guns[cugun];
        int x = PlayerControllerScript.CurrentBullets[cugun];
        Bullets.text = x+ "/" +PlayerControllerScript.totalBullets[cugun];
        Bulletprice.text = ""+ PlayerControllerScript.BulletCost[cugun];
    }
    public static void nextgun()
    {
        
        cugun=(cugun+1)%Guns.Length;
        Price.text = "Price: " + GunCost[cugun];
        if (!PlayerControllerScript.Gunsowned[cugun])
        {
            Price.text = "Price: " + GunCost[cugun];
            Price.enabled = true;
        }
        else
        {
            Price.text = "Owned";
            
        }
        gunspan.GetComponent<Image>().sprite = Guns[cugun];
        int x = PlayerControllerScript.CurrentBullets[cugun];
        Bullets.text = x + "/" + PlayerControllerScript.totalBullets[cugun];
        Bulletprice.text = "" + PlayerControllerScript.BulletCost[cugun];
    }
    public static void prevgun()
    {

        if (cugun <= 0)
        {
            cugun=Guns.Length-1;
        }
        else
        {
            cugun = (cugun - 1);
        }
        if (!PlayerControllerScript.Gunsowned[cugun])
        {
            Price.text = "Price: " + GunCost[cugun];
            Price.enabled = true;
        }
        else
        {
            Price.text = "Owned";
            //Price.enabled = false;
        }
        gunspan.GetComponent<Image>().sprite = Guns[cugun];
        int x = PlayerControllerScript.CurrentBullets[cugun];
        Bullets.text = x + "/" + PlayerControllerScript.totalBullets[cugun];
        Bulletprice.text = "" + PlayerControllerScript.BulletCost[cugun];
    }

    public static void buygun()
    {
        if (PlayerGoodies.coins >= GunCost[cugun])
        {
            if (!PlayerControllerScript.Gunsowned[cugun])
            {
                PlayerGoodies.coins = PlayerGoodies.coins - GunCost[cugun];
                PlayerControllerScript.Gunsowned[cugun] = true;
                Coins.text = "Coins : " + PlayerGoodies.coins;
                Price.text = "Owned";
            }
            else
            {
                print("already owned");
            }
        }
        else
        {
            print("No enough cash");
        }
        
    }
    public static void buyammo()
    {
        if (PlayerGoodies.coins >= PlayerControllerScript.BulletCost[cugun])
        {
            if (PlayerControllerScript.Gunsowned[cugun] )
            {
                PlayerGoodies.coins = PlayerGoodies.coins - PlayerControllerScript.BulletCost[cugun];
                PlayerControllerScript.totalBullets[cugun] +=AmmoSet[cugun];
                //PlayerPrefs.SetInt("guntotal"+cugun, PlayerControllerScript.totalBullets[cugun]);
                Coins.text = "Coins : " + PlayerGoodies.coins;
                PlayerControllerScript.CurrentBullets[cugun] = PlayerControllerScript.gunAmmo[cugun];
                PlayerControllerScript.canShoot=true;
                PlayerControllerScript.hasBullets=true;
                //PlayerControllerScript.firebutton.enabled=true;

                int x = PlayerControllerScript.CurrentBullets[cugun];
                Bullets.text = x + "/" + PlayerControllerScript.totalBullets[cugun];
            }
            else if(!PlayerControllerScript.Gunsowned[cugun])
            {
                print("Gun not purchased");
            }
            else
            {
                Bullets.text = "Max Capacity";
            }
        }
        else
        {
            print("No enough cash");
        }
    }
        // Update is called once per frame
    }