using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components 
    private Rigidbody2D rb2d;
    private Animator animator;   //let PlayerAttack(child) access but not other classes
    
    //movement
    public float moveSpeed = 5f;
    private Vector2 movement;

    //attack
    private float timeLeftTillAttack;
    public float resetAttackCooldown;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float attackRangeX;
    public float attackRangeY;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(name == "Player")
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (timeLeftTillAttack <= 0) //attack
            {
                timeLeftTillAttack = resetAttackCooldown;
                if (Input.GetButtonDown("Attack"))
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
                timeLeftTillAttack -= Time.deltaTime;
            }
        }
        else if(name == "Player2")
        {
            movement.x = Input.GetAxisRaw("Horizontal2");
            movement.y = Input.GetAxisRaw("Vertical2");
            if (timeLeftTillAttack <= 0) //attack
            {
                timeLeftTillAttack = resetAttackCooldown;
                if (Input.GetButtonDown("Attack2"))
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
                timeLeftTillAttack -= Time.deltaTime;
            }
        }

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        //Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
