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
    private Vector3 playerPosition;

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
            playerPosition = transform.position;
            if (randomNum == 0)  //up
            {
                //(transform.position.y+1).tag("Hazard")
                transform.Translate(0f, 1f, 0f);
            }
            else if (randomNum == 1) //down
            {
                transform.Translate(0f, -1f, 0f);
            }
            else if (randomNum == 2) //left
            {
                transform.Translate(-1f, 0f, 0f);

            }
            else if (randomNum == 3)//right
            {
                transform.Translate(1f, 0f, 0f);
            }
            timeLeftTillMove = resetTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            //Debug.Log("Touched");
            //animator.SetBool("isDead", true);
        }
    }
}
