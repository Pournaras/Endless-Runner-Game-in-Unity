using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public Animator animator;
    public GameObject Punch;
    //public GameObject Player;
    //PlayerController player_script;

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.15f;

    public Collider2D PunchPoint;

    public Transform ThePunchPoint;
    public float punchRange = 0.5f;
    public LayerMask villagerLayers;
    //private float punchtime = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        PunchPoint.enabled = false;

        //player_script = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) && !attacking)
            {
                attacking = true;
                attackTimer = attackCd;
                PunchPoint.enabled = true;

                //player_script.punching = true;

                animator.SetTrigger("Punch");
            }


        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;

                //player_script.punching = false;

                PunchPoint.enabled = false;
            }
        }

    }

    /*
    void Punch()
    {
        

        //Play punch animation
        animator.SetTrigger("Punch");

        //Detect villagers in range of punch
        Collider2D[] hitVillagers = Physics2D.OverlapCircleAll(PunchPoint.position, punchRange, villagerLayers);

        for(int i = 0; i < hitVillagers.Length; i++)
        {
            hitVillagers[i].GetComponent<VillagerController>().GetPunched();
        }
    }

    void OnDrawGizmosSelected()
    {
        if(PunchPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(PunchPoint.position, punchRange);
        
    }
    */

    

   
}
