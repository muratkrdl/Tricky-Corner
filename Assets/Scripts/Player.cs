using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 baseInput = Vector2.one;

    Vector2 rightandUp = Vector2.one;
    Vector2 leftandUp = new Vector2(-1,1);
    Vector2 leftandDown = new Vector2(-1,-1);
    Vector2 rightandDown = new Vector2(1,-1);

    bool isGoingUpOnTheStart = true;

    void Update() 
    {
        Move();
        RotateBox(); 
    }

    void Move()
    {
        Vector2 newPos = transform.position;
        newPos += baseInput * moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    void RotateBox()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isGoingUpOnTheStart)
            {
                if(baseInput == rightandUp)
                    baseInput = leftandUp;
                else if(baseInput == leftandUp)
                    baseInput = leftandDown;
                else if(baseInput == leftandDown)
                    baseInput = rightandDown;
                else if(baseInput == rightandDown)
                    baseInput = rightandUp;
            }
            else if(!isGoingUpOnTheStart)
            {
                if(baseInput == rightandUp)
                    baseInput = rightandDown;
                else if(baseInput == leftandUp)
                    baseInput = rightandUp;
                else if(baseInput == leftandDown)
                    baseInput = leftandUp;
                else if(baseInput == rightandDown)
                    baseInput = leftandDown;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Score"))
        {
            GameManager.Instace.IncreaseScore();
        }

        int randomIndex = Random.Range(0,4);
        if(randomIndex == 0)
        {
            baseInput *= -1;
            isGoingUpOnTheStart = !isGoingUpOnTheStart;
        }

        Destroy(other.transform.parent.gameObject);
        moveSpeed *= 1.01f;
    }

}
