using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public int keyNum;
    /*
    keyNums:
    up - 0
    down - 1 
    left - 2 
    right - 3
     */
    Vector2 movement;
    bool inZone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (moveSpeed != 0)
        {
            movement.x = moveSpeed;
        }
        else
        {
            movement.x = -5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inZone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone = false;
        Destroy(gameObject);
    }

    //Checked for the right pressed key by the number of key and destroy gameObj after that
    void PressedRightKey()
    {
        if (inZone) {
            switch (keyNum)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        Destroy(gameObject);
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        Destroy(gameObject);
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        Destroy(gameObject);
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PressedRightKey();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

}
