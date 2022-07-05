using UnityEngine;
using System;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public int keyNum;
    private bool _status; //True destroyed by player, false by zone, than hitting player
    [SerializeField] private bool _mobile;
    public ButtonMobile upButton;
    public ButtonMobile downButton;
    public ButtonMobile leftButton;
    public ButtonMobile rightButton;
    public event Action<bool, int> OnStatusChanged;

    /*
    keyNums:
    up - 0
    down - 1 
    left - 2 
    right - 3
     */
    private Vector2 _movement;
    private bool _inZone = false;
    private bool _inZoneOne = false;
    private bool _inZoneTwo = false;
    [SerializeField] private int _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_mobile)
        {
            upButton = GameObject.FindWithTag("ButtonUp").GetComponent<ButtonMobile>();
            downButton = GameObject.FindWithTag("ButtonDown").GetComponent<ButtonMobile>();
            leftButton = GameObject.FindWithTag("ButtonLeft").GetComponent<ButtonMobile>();
            rightButton = GameObject.FindWithTag("ButtonRight").GetComponent<ButtonMobile>();
        }
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
        switch (collision.tag)
        {
            case "KeyPressedLocation":
                _inZone = true;
                break;
            case "KeyLocOne":
                _inZoneOne = true;
                break;
            case "KeyLocTwo":
                _inZoneTwo = true;
                break; 
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
    void PressedRightKeyMobile()
    {
        if (_inZone)
        {
            switch (keyNum)
            {
                case 0:
                    if (upButton.IsActivate())
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    if(downButton.IsActivate() || leftButton.IsActivate() || rightButton.IsActivate())
                    {
                        DestroyArrow();
                    }
                    break;
                case 1:
                    if (downButton.IsActivate())
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    if (upButton.IsActivate() || leftButton.IsActivate() || rightButton.IsActivate())
                    {
                        DestroyArrow();
                    }
                    break;
                case 2:
                    if (leftButton.IsActivate())
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    if (upButton.IsActivate() || downButton.IsActivate() || rightButton.IsActivate())
                    {
                        DestroyArrow();
                    }
                    break;
                case 3:
                    if (rightButton.IsActivate())
                    {
                        _status = true;
                        DestroyArrow();
                    }
                    if (upButton.IsActivate() || downButton.IsActivate() || leftButton.IsActivate())
                    {
                        DestroyArrow();
                    }
                    break;
            }
        }
    }
    private void DestroyArrow()
    {
        //Debug.Log("Destroy by button");
        OnStatusChanged.Invoke(_status, keyNum);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (!_mobile) {
            PressedRightKey();
        }
        else
        {
            PressedRightKeyMobile();
        }

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
