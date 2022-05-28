using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    private Vector2 _movement;
    public IEnemyBattleController enemyBattleController; //For constructing battle
    public event System.Action<int> GetDamage;
    public event System.Action<List<float>> SetAnimation;
    public event System.Action OnKilled;
    public Animator animator;
    public event System.Action<int> HeroAction;
    static public float speedModificator = 1f;

    [SerializeField] protected GameObject leftArrow;
    [SerializeField] protected GameObject rightArrow;
    [SerializeField] protected GameObject upArrow;
    [SerializeField] protected GameObject downArrow;

    [SerializeField] private List<float> _arrowDelay = null;
    [SerializeField] private List<float> _animationSpeed = null;
    [SerializeField] private List<int> _arrowOrder = null;

    //public Enemy(Vector3 spawnZone)
    //{
    //    this.spawnZone = spawnZone;
    //}
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyBattleController = GetComponent<IEnemyBattleController>();
        
    }
    private void SetAnimationSpeed()
    {
        for (int i = 0; i < _arrowDelay.Count-1; i++)
        {
            if (_arrowDelay[i]>0 && _arrowDelay[i]<=2)
            {

            }
            else if(_arrowDelay[i] > 2 && _arrowDelay[i] <= 4)
            {

            }else if (_arrowDelay[i] > 4 && _arrowDelay[i] <= 6)
            {

            }else if (_arrowDelay[i] > 6 && _arrowDelay[i] <= 8)
            {

            }else if (_arrowDelay[i] > 8 && _arrowDelay[i] <= 10)
            {

            }else if (_arrowDelay[i] > 10)
            {

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_moveSpeed != 0)
        {
            _movement.x = _moveSpeed*-1;
        }
        else
        {
            _movement.x = -3;
        }
        Debug.Log("EnemySuccess");
        speedModificator = 1f;
    }
    private void OnEnable()
    {
        enemyBattleController.OnArrowDestroyed += ArrowDestroied;
    }
    private void OnDisable()
    {
        enemyBattleController.OnArrowDestroyed -= ArrowDestroied;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Movement - move an enemy at one side left or right
    void Movement()
    {
        animator.SetFloat("Speed", speedModificator);
        rb.MovePosition(rb.position + _movement * Time.fixedDeltaTime*speedModificator);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetAnimation.Invoke(_animationSpeed);
        speedModificator = 0;
        _movement.x = 0;
        animator.SetBool("Combat", true);
        if (_arrowOrder.Count > 0) {
            enemyBattleController.SpawnArrows(leftArrow, rightArrow, upArrow, downArrow, _arrowDelay, _arrowOrder);
        }
        else{
            enemyBattleController.SpawnArrows(leftArrow, rightArrow, upArrow, downArrow, _arrowDelay);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        speedModificator = 1;
        OnKilled.Invoke();
    }
    private void FixedUpdate()
    {
        Movement();
        enemyBattleController.DetectWinBattle(this);
    }
    public void ArrowDestroied(bool arrowStatus, int keyNum)
    {
        if (!arrowStatus || keyNum==3)
        {
            StartCoroutine(Punch(arrowStatus));
        }
        if (arrowStatus) {
            HeroAction(keyNum);
            if (keyNum != 3)
            {
                StartCoroutine(HurtAnimation());
            }
        }
    }
    private IEnumerator HurtAnimation()
    {
        if (_animationSpeed.Count > 0)
        {
            float test = _animationSpeed.First();
            animator.SetFloat("AnimationSpeed", test);
            _animationSpeed.Remove(_animationSpeed.First());
        }
        animator.SetBool("Hurt", true);
        yield return new WaitForSeconds(0f);
        animator.SetBool("Hurt", false);
    }
    private IEnumerator Punch(bool arrowStatus)
    {
        if (_animationSpeed.Count > 0)
        {
            float test = _animationSpeed.First();
            animator.SetFloat("AnimationSpeed", test);
            _animationSpeed.Remove(_animationSpeed.First());
        }
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0f);
        animator.SetBool("Attack", false);
        if(!arrowStatus) GetDamage.Invoke(_damage);
    }
}
