using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDie : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ZombieSpawnScript.ZombieCount -= 1;
        PlayerGoodies player=FindAnyObjectByType<PlayerGoodies>();
        PlayerGoodies.updatekills(1);
       PlayerGoodies.UpdateCoins(Random.Range(2,15));
        Debug.Log("Coins: "+player.getCoins());

        CapsuleCollider[] c = animator.gameObject.GetComponentsInChildren<CapsuleCollider>();
        foreach (CapsuleCollider i in c)
        {
            Debug.Log(i.gameObject.name);
            Destroy(i);
        }
        
        Destroy(animator.gameObject.GetComponent<Rigidbody>());
        Destroy(animator.gameObject.GetComponent<NavMeshAgent>());   
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Destroy(animator.gameObject);   
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
