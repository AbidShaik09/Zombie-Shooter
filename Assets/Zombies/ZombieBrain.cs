using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Processors;
using System;
public class ZombieBrain : MonoBehaviour
{
    CharacterController controller;
    public Vector3 scalemid = new Vector3(1.5f, 1.3f, 1.5f);
    public Vector3 scaletall = new Vector3(1.7f, 1.3f, 1.7f);
    public int ZombieHealth { get; set; }
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    [SerializeField] GameObject Player;
    public NavMeshAgent agent;
    bool Dead = false;
    // Update is called once per frame
    private void Start()
    {
        
        ZombieHealth = 100;
        animator = GetComponent<Animator>();
        controller = FindAnyObjectByType<CharacterController>();
        Player = controller.gameObject;
    }
    public static void DealDamage(ZombieBrain target,int x)
    {
        if (target == null) return;
        target.Damage(x);
    }
    public void Damage(int x)
    {
        if (!Dead)
        {
            ZombieHealth -= x;
            if (ZombieHealth <= 0 && !Dead)
            {
                Dead = true;
                agent.gameObject.GetComponent<Animator>().Play("Die");

            }
        }
    }
    void Update()
    {

        if (Player != null)
        {
            if (agent != null)
            {
                try
                {
                    agent.SetDestination(Player.transform.position);
                }
                catch(Exception )
                {
                    print("Waiting");
                }
                if (agent.velocity == Vector3.zero)
                {
                    animator.SetBool("IsIdol", true);
                }
                else
                {
                    animator.SetBool("IsIdol", false);
                }

                if (agent.gameObject.transform.position.y < -1)
                {
                    
                    ZombieSpawnScript.ZombieCount -= 1;
                    Destroy(agent.gameObject);
                }

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            DealDamage();   
           // Debug.Log(PlayerControllerScript.GetHealth());
        }
    }
    void DealDamage()
    {
        PlayerControllerScript.Damage(1);
        int health=PlayerControllerScript.GetHealth();
        if (health==0)
        {
          //  Debug.Log("Dead");
        }
    }
}
