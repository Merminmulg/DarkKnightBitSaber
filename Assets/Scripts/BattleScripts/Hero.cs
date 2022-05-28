using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Hero : MonoBehaviour
{
    public event Action<int> OnHealthChanged;
    public event Action OnHeroDeath;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealt;
    public bool isAlive = true;

    private List<float> _animationSpeed = null;
    public int MaxHealth{ get { return _maxHealt; } }
    private Animator _heroAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _heroAnimator = GetComponent<Animator>();
        if(OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(_health);
        }
    }
    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health < 0) 
            _health = 0;

        if (OnHealthChanged!= null && _health >= 0)
        {
            StartCoroutine(HurtAnimation());
            OnHealthChanged.Invoke(_health);
            if(_health<=0)StartCoroutine(Death());
        }
    }
    private IEnumerator Death()
    {
        _heroAnimator.SetBool("Death", true);
        isAlive = false;
        yield return new WaitForSeconds(2f);
        OnHeroDeath.Invoke();
    }

    public void SetAnimationSpeed(List<float> animationSpeed)
    {
        _animationSpeed = animationSpeed.GetRange(0, animationSpeed.Count);
    }

    public void Action(int keyNum)
    {
        StartCoroutine(ActionAnimation(keyNum+1));
    }
    private IEnumerator HurtAnimation()
    {
        float test = _animationSpeed.First();
        _heroAnimator.SetFloat("AnimationSpeed", test);
        _animationSpeed.Remove(_animationSpeed.First());
        _heroAnimator.SetBool("Hurt", true);
        yield return new WaitForSeconds(0f);
        _heroAnimator.SetBool("Hurt", false);
    }
    private IEnumerator ActionAnimation(int animationNumber)
    {
        float test = _animationSpeed.First();
        _heroAnimator.SetFloat("AnimationSpeed", test);
        _animationSpeed.Remove(_animationSpeed.First());
        _heroAnimator.SetInteger("KeyPressedAction", animationNumber);
        yield return new WaitForSeconds(0f);
        _heroAnimator.SetInteger("KeyPressedAction", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
