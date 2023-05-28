using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public static PlayerControllerScript playerControllerScript;
    public static bool Healing = false;
    public Image activeImage;
    public Sprite[] gunimages;
    // Start is called before the first frame update
    public static int force = 5;
   [SerializeField]
    private float _speed;
    public static bool[] Gunsowned;
    //public int[] gunsowned;
    public static float rotationofplayer;
    public static int[] totalBullets;
    public static int[] CurrentBullets; 
    public GameObject gunspot;
    public GameObject grenade;
    public static GameObject Grenade;
    public static bool canShoot = true;
    public static float[] recoilGuns;
    public static int[] gunAmmo;
    public static int GrenadeCount;
    public static bool hasBullets;
    static GameObject GunSpot;
    static GameObject GrenadeSpot;
    static GameObject Bullet;
    //public static Button firebutton;
    //public Button firebuttoninstance;
    private PlayerControls _playerActions;
    public GameObject rightController;
    public static GameObject RightController;
    public static CharacterController _rbody;
    private Vector2 _moveInput;
    public static int HealCount;
    private Vector2 _moveDir;
    public static Vector3 _moveOutput;
    private Vector3 moveDir=Vector3.zero;
    [SerializeField] float gravity = -9.8f;
    public GameObject[] gun;
    public GameObject[] Bullets;
    public static int[] GunDamage;
    public static float[] reloadTime;
    public static int activeGun =0;
    public static int[] BulletCost;
    public int[] bulletcost;
    static Animator _animator;
    static Vector3 Angle;
    private static int Health;
    public static int GetHealth()
    {
        return Health;
    }
    public static void Damage(int x)
    {
        Health -= x;
        if (Health < 0)
        {
            Health = 0;
            PlayerPrefs.SetInt("grenadecount",GrenadeCount);
            PlayerPrefs.SetInt("activegun",activeGun);
            for(int i = 0; i < gunAmmo.Length; i++)
            {
                if (Gunsowned[i])
                    PlayerPrefs.SetInt("gun" + i, 1);
                else
                    PlayerPrefs.SetInt("gun" + i, 0);
                PlayerPrefs.SetInt("gunammo"+i, gunAmmo[i]);
                PlayerPrefs.SetInt("guntotal" + i, totalBullets[i]);
            }
            PlayerPrefs.SetInt("coins", PlayerGoodies.coins);
            PlayerGoodies.setMaxKills(PlayerGoodies.kills);
            PlayerPrefs.SetInt("maxkills",PlayerGoodies.getMaxKills());
            PlayerPrefs.SetInt("healcount", 3);
            PlayerPrefs.SetInt("grenadecount", 6);
            _animator.Play("Die");
        }
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("grenadecount")){
            GrenadeCount = 5;
            PlayerPrefs.SetInt("grenadecount", GrenadeCount);
        }
        if (!PlayerPrefs.HasKey("healcount"))
        {
            HealCount = 3;
            PlayerPrefs.SetInt("healcount", GrenadeCount);
        }
        HealCount = 3;
        GrenadeCount = 6;
        RightController = rightController;
        print("coins: " + PlayerPrefs.GetInt("coins"));
        BulletCost = bulletcost;
        Gunsowned = new bool[5];
        activeGun = PlayerPrefs.GetInt("activegun");
       // firebutton = firebuttoninstance;
        playerControllerScript= GetComponent<PlayerControllerScript>();
        GunDamage = new int[5];
        GunDamage[0] = 30;
        GunDamage[1] = 40;
        GunDamage[2] = 20;
        GunDamage[3] = 70;
        GunDamage[4] = 100;
        recoilGuns= new float[5];
        recoilGuns[0] = 0.5f;
        recoilGuns[1] = 0.3f;
        recoilGuns[2] = 0.1f;
        recoilGuns[3] = 0.3f;
        recoilGuns[4] = 0.2f;
        gunAmmo = new int[5];
        gunAmmo[0] = 12;
        gunAmmo[1] = 14;
        gunAmmo[2] = 50;
        gunAmmo[3] = 6;
        gunAmmo[4] = 10;
        reloadTime = new float[5];
        reloadTime[0] = 2.0f;
        reloadTime[1] = 2.8f;
        reloadTime[2] = 5.0f;
        reloadTime[3] = 2.5f;
        reloadTime[4] = 1.0f;
        totalBullets = new int[5];
        
        CurrentBullets = new int[5];
        
        Grenade=grenade;
        Bullet = Bullets[activeGun];
        GunSpot = GameObject.FindGameObjectWithTag("gunspot");
        GrenadeSpot = GameObject.FindGameObjectWithTag("grenadespot");
        Health = 200;
        
        //Debug.Log("Game Started");
        for(int i = 0; i < gun.Length; i++)
        {
            CurrentBullets[i] = PlayerPrefs.GetInt("gunammo"+i);
            totalBullets[i] = PlayerPrefs.GetInt("guntotal"+i);
            if (PlayerPrefs.GetInt("gun" + i) == 1)
            {
                Gunsowned[i] = true;
            }

            if (i != activeGun)
            {
                gun[i].SetActive(false);
            }

            else
            {
                gun[i].SetActive(true);
            }
        }
        totalBullets[0] = 100;
        Gunsowned[0] = true;
        hasBullets = true;
        _animator = GetComponent<Animator>();
        _animator.SetBool("Dead", false);
        activeImage.sprite = gunimages[activeGun];
       
    }
    void Awake()
    {
        _playerActions = new PlayerControls();
        _rbody = GetComponent<CharacterController>();
        if(_rbody is null)
        {
            Debug.Log("RigidBody is Null");

        }
    }
    private void OnEnable()
    {
        if(_playerActions!=null)
        _playerActions.Player.Enable();
    }
    private void OnDisable()
    {
        if(_playerActions!=null)
        _playerActions.Player.Disable();
    }
    private void FixedUpdate()
    {
        if (_animator.gameObject == null)
        {
            Time.timeScale = 0;
        }


        _moveInput = _playerActions.Player.Move.ReadValue<Vector2>();
        _moveDir= _playerActions.Player.Look.ReadValue<Vector2>();

        float x = float.Parse((_moveInput.x).ToString());
        float y = float.Parse((_moveInput.y).ToString());
        //float x = _playerActions.Player.Move.ReadValue;
        moveDir = new Vector3(_moveDir.x,0, _moveDir.y);
        moveDir = transform.TransformDirection(moveDir) * _speed;

        _moveOutput.x = _moveInput.x;
        _moveOutput.y = 30*(gravity);
        _moveOutput.z = _moveInput.y;
        
        _rbody.Move(_moveOutput * _speed / 10);
        float yy = Mathf.Rad2Deg * (Mathf.Atan2(_moveDir.y, _moveDir.x));
        
        float xx = Mathf.Rad2Deg * (Mathf.Atan2(y,x));
        if (yy !=0.00)
        {

            //_animator.SetBool("isIdle",false);
            Angle = new Vector3(0, 90 - yy, 0);
            rotationofplayer = yy;
            //Debug.Log(Angle);
            _rbody.transform.rotation = Quaternion.Euler(Angle);
            if (canShoot && hasBullets)
                FireBullet();
        }

        float animdecider =xx-yy;
        //print("Angle = " + animdecider);
        if (xx != 0.00)
        {
            _animator.SetBool("isIdle", false);
            if(animdecider<126 && animdecider > 34)
            {
                _animator.SetBool("WalkFront", true);
                _animator.SetBool("WalkLeft", false);
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkBack", false);
            }
            if (animdecider < 181 && animdecider > 124 ||  animdecider>-180 && animdecider< -146)
            {

                _animator.SetBool("WalkFront", false);
                _animator.SetBool("WalkLeft", true);
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkBack", false);
            }
            if ( animdecider > -146 && animdecider < -54)
            {

                _animator.SetBool("WalkFront", false);
                _animator.SetBool("WalkLeft", false);
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkBack", true);
            }
            if(animdecider>-55 && animdecider<35 )
            {
                _animator.SetBool("WalkFront", false);
                _animator.SetBool("WalkLeft", false);
                _animator.SetBool("WalkRight", true);
                _animator.SetBool("WalkBack", false);
            }
            //print(_animato);
            //Angle = new Vector3(0, 90 - yy, 0);
            //Debug.Log(Angle);
            //_rbody.transform.rotation = Quaternion.Euler(Angle);
        }
        else
        {
            _animator.SetBool("isIdle", true);
        }
    }
    public void changeNextGun()
    {
        canShoot = true;
        int size = gun.Length;

        activeGun = (activeGun + 1) % size;
        while (!Gunsowned[activeGun])
        {
            activeGun = (activeGun + 1) % size;
        }
        changeGun();
        activeImage.sprite = gunimages[activeGun];
    }
    public void changePrevGun()
    {
        canShoot = true;
        int size = gun.Length;

        if (activeGun <= 0)
        {
            activeGun= Gunsowned.Length - 1;
        }
        else
        {
            activeGun = (activeGun- 1);
        }
        while (!Gunsowned[activeGun])
        {
            if(activeGun <= 0)
        {
                activeGun = Gunsowned.Length - 1;
            }
        else
            {
                activeGun = (activeGun - 1);
            }
        }
        changeGun();
        activeImage.sprite = gunimages[activeGun];
    }
    public void changeGun()
    {
       // firebutton.enabled = true;
       
        

        if (CurrentBullets[activeGun] > 0)
        {
            hasBullets = true;
            print("First if is true");
        }
        else if (totalBullets[activeGun] >0)
        {
            
            hasBullets = true;
            StartCoroutine(reloadGun());
        }
        else
        {
            hasBullets= false;
            AmmoCountScript.display.text = "No Ammo";
        }
        print(hasBullets);
        Bullet = Bullets[activeGun];
        for (int i = 0; i < gun.Length; i++)
        {
            if (i != activeGun)
            {
                gun[i].SetActive(false);
            }
            else
            {
                gun[i].SetActive(true);
            }
        }
    }
    public static void store()
    {
        Time.timeScale = 0;
        LoadScene.Store();
    }
    [Obsolete]
    public static void resume()
    {
        
        LoadScene.Game();
        Time.timeScale = 1;
    }
    public static void FireBullet()
    {
        //print("fire!");
        if (canShoot && hasBullets) { 
            
            
            if (CurrentBullets[activeGun] <= 0)
            {
                hasBullets= false;
            }
            else            
            playerControllerScript.StartCoroutine(recoil());
        }
        if (!hasBullets)
        {
            playerControllerScript.StartCoroutine(reloadGun());
        }
        
        
    }
    static IEnumerator reloadGun()
    {
        if (totalBullets[activeGun] <= 0)
        {
          //  firebutton.enabled = false;
            AmmoCountScript.display.text = "No Ammo";
        }
        else
        {
            //firebutton.gameObject.SetActive(false);
            AmmoCountScript.display.text = "Reloading";
            
            yield return new WaitForSeconds(reloadTime[activeGun]);
            if (totalBullets[activeGun] > gunAmmo[activeGun])
            {
                CurrentBullets[activeGun] = gunAmmo[activeGun];
                totalBullets[activeGun] -= gunAmmo[activeGun];
            }
            else
            {
                CurrentBullets[activeGun] = totalBullets[activeGun];
                totalBullets[activeGun] = 0;
            }
            hasBullets = true;

           
            // firebutton.gameObject.SetActive (true);
        }
    }
    static IEnumerator recoil()
    {
        canShoot = false;
        CurrentBullets[activeGun] -= 1;
        AmmoCountScript.display.text = CurrentBullets[activeGun] +"/"+totalBullets[activeGun];
        Vector3 p = GunSpot.transform.position;
        GameObject curr = Instantiate(Bullet);
        curr.transform.position = p;
        curr.transform.rotation = GunSpot.transform.rotation;
        yield return new WaitForSeconds(recoilGuns[activeGun]);

        canShoot = true;
    }
    public static void LaunchGrenade()
    {
        if (GrenadeCount <= 0)
        {
     //       LoadScene.WatchAdsScene();
        }
        else
        {
            GrenadeCount -= 1;

            GameObject curr = Instantiate(Grenade);
            curr.transform.position = GrenadeSpot.transform.position;
            curr.transform.rotation = GrenadeSpot.transform.rotation;
            //curr.transform.rotation = GrenadeSpot.transform.rotation;
            curr.GetComponent<Rigidbody>().AddForce(curr.GetComponent<Rigidbody>().transform.forward * force, ForceMode.VelocityChange);
        }

    }
    public static void Heal()
    {
        
        if (HealCount <= 0 || Healing==true)
        {
            if (HealCount <= 0)
            {
                HealCount = 0;
              //  LoadScene.WatchAdsScene();
            }
        }
        else
        {
            playerControllerScript.StartCoroutine(Healplayer());
        }
    }

    static IEnumerator Healplayer()
    {
        Healing = true;
        GameObject healeffect = GameObject.FindGameObjectWithTag("HealEffect");
        ParticleSystem heffect = healeffect.GetComponent<ParticleSystem>();
        heffect.Play();
        Health += 150;
        if (Health > 200)
        {
            Health = 200;
        }
        HealCount -= 1;
        yield return new WaitForSeconds(1);
        heffect.Stop();
        Healing = false;

    }
}