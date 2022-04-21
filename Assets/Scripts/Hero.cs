using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero : MonoBehaviour
{
    public event Action<int> OnHealthChanged;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealt;
    public int MaxHealth{ get { return _maxHealt; } }
    // Start is called before the first frame update
    void Start()
    {
        if(OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(_health);
        }
    }
    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (OnHealthChanged!= null)
        {
            OnHealthChanged.Invoke(_health);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
