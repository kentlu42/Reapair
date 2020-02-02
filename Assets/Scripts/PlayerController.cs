using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components 
    private Rigidbody2D rb2d;
    private Animator animator;   //let PlayerAttack(child) access but not other classes
    
    //movement
    private float moveSpeed = 5f;
    private Vector2 movement;
    //private bool faceR = true;

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
        if (name == "Player1")
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("speed", Mathf.Abs(movement.x));

            if (timeLeftTillAttack <= 0)
            {
                if (Input.GetButtonDown("Attack"))
                {
                    animator.SetBool("isAttacking", true);
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        Destroy(enemiesToDamage[i].gameObject);
                    }
                    timeLeftTillAttack = resetAttackCooldown;
                }
            }
            else
            {
                animator.SetBool("isAttacking", false);
                timeLeftTillAttack -= Time.deltaTime;
            }
        }
        else if(name == "Player2")
        {
            movement.x = Input.GetAxisRaw("Horizontal2");
            movement.y = Input.GetAxisRaw("Vertical2");
            animator.SetFloat("speed", Mathf.Abs(movement.x));

            if (timeLeftTillAttack <= 0) //attack
            {
                if (Input.GetButtonDown("Attack2"))
                {
                    animator.SetBool("isAttacking", true);
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for( int i=0; i<enemiesToDamage.Length; i++)
                    {
                        Destroy(enemiesToDamage[i]);
                    }
                    timeLeftTillAttack = resetAttackCooldown;
                }
            }
            else
            {
                animator.SetBool("isAttacking", false);
                timeLeftTillAttack -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.DrawWireCube(attackPos.position, new Vector2(attackRangeX, attackRangeY));
    }
}
