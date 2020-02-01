using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementTranslate : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    //Translate implementation of movement
    private float timeLeftTillMove;
    private float resetTimer = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        timeLeftTillMove -= Time.deltaTime;
        if (timeLeftTillMove <= 0)
        {
            /*int randomNum = Random.Range(0, 4); //range 0-3
            if (randomNum == 0)  //up
            {
                //hit = Physics2D.Raycast(transform.position, Vector2.up);
                //Debug.DrawRay(transform.position, Vector2.up);
                //if (!hit.collider) 
                    transform.Translate(0f, 1f, 0f);
            }
            else if (randomNum == 1) //down
            {
                //hit = Physics2D.Raycast(transform.position, Vector2.down);
                //Debug.DrawRay(transform.position, Vector2.down);
                //if (!hit.collider) 
                    transform.Translate(0f, -1f, 0f);
            }
            else if (randomNum == 2) //left
            {
                //hit = Physics2D.Raycast(transform.position, Vector2.left);
                //Debug.DrawRay(transform.position, Vector2.left);
                //if (!hit.collider) 
                transform.Translate(-1f, 0f, 0f);

            }
            else if (randomNum == 3)//right
            {
                //hit = Physics2D.Raycast(transform.position, Vector2.right);
                //Debug.DrawRay(transform.position, Vector2.right);
                //if (!hit.collider) 
                transform.Translate(1f, 0f, 0f);
            }*/

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
            if(hit.collider != null)
            {
                //Debug.Log(hit.collider.name);
                Debug.Log(hit.point);
            }
           //transform.Translate(-1f, 0f, 0f);

            timeLeftTillMove = resetTimer;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector2.left));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Touched");
            //animator.SetBool("isDead", true);
        }
    }
}
