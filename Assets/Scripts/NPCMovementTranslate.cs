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
            int randomNum = Random.Range(0, 4); //range 0-3
            if (randomNum == 0)  //up
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
                if (hit.collider.name != "Border" && hit.collider.name != "Player(clone)")   //check if spawn point has anyone on it. 
                {
                    transform.Translate(Vector2.up);
                }
            }
            else if (randomNum == 1) //down
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
                if (hit.collider.name != "Border" && hit.collider.name != "Player(clone)")   //check if spawn point has anyone on it. 
                {
                    transform.Translate(Vector2.down);
                }
            }
            else if (randomNum == 2) //left
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
                if (hit.collider.name != "Border" && hit.collider.name != "Player(clone)")   //check if spawn point has anyone on it. 
                {
                    transform.Translate(Vector2.left);
                }
            }
            else if (randomNum == 3)//right
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
                if (hit.collider.name != "Border" && hit.collider.name != "Player(clone)")   //check if spawn point has anyone on it. 
                {
                    transform.Translate(Vector2.right);
                }
            }
            timeLeftTillMove = resetTimer;
        }
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