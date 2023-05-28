using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnScript : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject player;
    public static int ZombieCount;
    //float timer = 0f;
    bool notSpawned = true;
    public int countDown1 = 25;// public int countDown2 = 4;
    public static int cnt = 0;
    int seconds;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        ZombieCount = 0;
        characterController =FindAnyObjectByType<CharacterController>();
        
        player = characterController.gameObject;
        //print(player.name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        
        if(notSpawned) {
            if (player != null)
            {
                
                StartCoroutine(spawnzombies());

                

            }
            
            
            
        }
        

        //timer += Time.deltaTime;
        //countDown =(int) timer%(60*x);
        //if (countDown == 1)
        //{
        //    spawnzombie();
        //}
    }

    public IEnumerator spawnzombies()
    {
        notSpawned = false;
        int dir1 = Random.Range(0, 10);
        int dir2 = Random.Range(0, 10);
        Vector3 playerPos = player.transform.position;
        Vector3 newPos = new Vector3(playerPos.x + Random.Range(7, 20) * dire(dir1), playerPos.y, playerPos.z + Random.Range(7, 20) * dire(dir2));
        Instantiate(spawn, newPos, Quaternion.identity);
        ZombieCount += 1;
        dir1 = Random.Range(0, 10);
        dir2 = Random.Range(0, 10);
        playerPos = player.transform.position;
        newPos = new Vector3(playerPos.x + Random.Range(7, 20) * dire(dir1), playerPos.y, playerPos.z + Random.Range(7, 20) * dire(dir2));
        Instantiate(spawn, newPos, Quaternion.identity);
        //StartCoroutine(spawnzombie(newPos));
        ZombieCount += 1;
        dir1 = Random.Range(0, 10);
        dir2 = Random.Range(0, 10);
        playerPos = player.transform.position;
        newPos = new Vector3(playerPos.x + Random.Range(7, 20) * dire(dir1), playerPos.y, playerPos.z + Random.Range(7, 20) * dire(dir2));
        Instantiate(spawn, newPos, Quaternion.identity);
        ZombieCount += 1;
        //StartCoroutine(spawnzombie(newPos));

        //ZombieCount += 1;
        cnt++;
        
        //Instantiate(spawn, newPos, Quaternion.identity);
        yield return new WaitForSeconds(countDown1);
        notSpawned = true;
    }
    int dire(int x)
    {

        
        if (x < 5)
        {
            return -1;
        }
        return 1;
    }
    public bool isValid(Vector3 pos)
    {
        print("Checking...");
        if(pos.z!>145 && pos.x!>142 && pos.z!<14 && pos.x!< 14)
        return true;
        else
            return false;
    }
    void spawnzombie()
    {
        
    }
}
