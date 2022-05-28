using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private float _moveSpeed;
    public int playerLevel;
    private Vector2 _playerPosition;
    private Vector2 _direction;
    void Start()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Walking();
    }
    void Walking()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _moveSpeed * Time.deltaTime);
    }
}
