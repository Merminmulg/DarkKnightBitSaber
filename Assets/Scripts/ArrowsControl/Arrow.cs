using UnityEngine;
using System;
public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public int keyNum;
    private bool _status; //True destroyed by player, false by zone, than hitting player
    public event Action<bool> OnStatusChanged;
    /*
    keyNums:
    up - 0
    down - 1 
    left - 2 
    right - 3
     */
    private Vector2 _movement;
    private bool _inZone = false;
    [SerializeField] private int _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        if (moveSpeed != 0)
        {
            _movement.x = moveSpeed*_direction;
        }
        else
        {
            _movement.x = 5*_direction;
        }
        Debug.Log("ArrowSuccess");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KeyPressedLocation") 
            {
            _inZone = true;
            return;
        }
        if (collision.tag == "ArrowDestroyLocation")
        {
            _inZone = false;
            _status = false;
            DestroyArrow();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _inZone = false;
    }

    //Checked for the right pressed key by the number of key and destroy gameObj after that
    void PressedRightKey()
    {
        if (_inZone) {
            switch (keyNum)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    break;
            }
        }
    }
    private void DestroyArrow()
    {
        //Debug.Log("Destroy by button");
        OnStatusChanged.Invoke(_status);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        PressedRightKey();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * Time.fixedDeltaTime);
    }
    //private void OnGUI()
    //{
    //    Event e = Event.current;
    //    if (e.isKey)
    //    {
    //        Debug.Log("Key code: - "+ e.keyCode);
    //    }
    //}
}
