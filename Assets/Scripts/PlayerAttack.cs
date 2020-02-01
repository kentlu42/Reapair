using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerMovement
{
    private float attackCooldown;
    public float resetAttackCooldown;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float attackRangeX;
    public float attackRangeY;

    // Update is called once per frame
    void Update()
    {
        if(attackCooldown <= 0) //attack
        {
            attackCooldown = resetAttackCooldown;
            if (Input.GetKey(KeyCode.Space))
            {
                /*Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for( int i=0; i<enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>.health -= danage;
                }*/
                Debug.Log("attacked");
                //animator.SetBool("");
            }
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        //Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
