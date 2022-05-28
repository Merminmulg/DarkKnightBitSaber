using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Text _render;
    [SerializeField] private Hero _target;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        _target.OnHealthChanged += UpdateValue;    
    }
    private void OnDisable()
    {
        _target.OnHealthChanged -= UpdateValue;
    }
    private void UpdateValue(int value)
    {
        if (_target==null) return;
        _render.text = value.ToString()+"/"+_target.MaxHealth.ToString();
    }

}
