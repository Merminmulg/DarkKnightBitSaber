using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int _damage;
    private Vector2 _movement;
    private IEnemyBattleController _enemyBattleController; //For constructing battle
    public event System.Action<int> GetDamage;


    [SerializeField] protected GameObject leftArrow;
    [SerializeField] protected GameObject rightArrow;
    [SerializeField] protected GameObject upArrow;
    [SerializeField] protected GameObject downArrow;

    //public Enemy(Vector3 spawnZone)
    //{
    //    this.spawnZone = spawnZone;
    //}
    private void Awake()
    {
        _enemyBattleController = GetComponent<IEnemyBattleController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (moveSpeed != 0)
        {
            _movement.x = moveSpeed;
        }
        else
        {
            _movement.x = -5;
        }
        Debug.Log("EnemySuccess");
    }
    private void OnEnable()
    {
        _enemyBattleController.OnArrowDestroyed += Punch;
    }
    private void OnDisable()
    {
        _enemyBattleController.OnArrowDestroyed += Punch;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Movement - move an enemy at one side left or right
    void Movement()
    {
        rb.MovePosition(rb.position + _movement * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(_enemyBattleController.SpawnArrows(leftArrow, rightArrow, upArrow, downArrow));
        _movement.x = -1;
    }
    private void FixedUpdate()
    {
        Movement();
        _enemyBattleController.DetectWinBattle(gameObject);
    }
    public void Punch(bool arrowStatus)
    {
        if (!arrowStatus) GetDamage.Invoke(_damage);
    }
}
