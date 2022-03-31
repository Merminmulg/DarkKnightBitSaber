using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    Vector2 movement;
    IEnemyBattleController enemyBattleController;

    [SerializeField] public GameObject leftArrow;
    [SerializeField] public GameObject rightArrow;
    [SerializeField] public GameObject upArrow;
    [SerializeField] public GameObject downArrow;

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

    // Update is called once per frame
    void Update()
    {

    }
    void Movement()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void FixedUpdate()
    {
        Movement();
    }
}
internal interface IEnemyBattleController
{
    public IEnumerator Battle(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow);
}

internal class SkeletBattleController : MonoBehaviour, IEnemyBattleController
{
    [SerializeField] public List<float> arrowDelay;
    [SerializeField] public List<int> arrowOrder;
    public IEnumerator Battle(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow)
    {
        for(int i = 0; i < arrowOrder.Count; i++)
        {
            if(arrowOrder[i] <= 0)
            {
                switch (arrowOrder[i])
                {
                    case 0:
                        GameObject.Instantiate(upArrow);
                        break;
                    case 1:
                        GameObject.Instantiate(downArrow);
                        break;
                    case 2:
                        GameObject.Instantiate(leftArrow);
                        break;
                    case 3:
                        GameObject.Instantiate(rightArrow);
                        break;
                }
            }
            if (arrowDelay[i] <= 0)
            {
               yield return new WaitForSeconds(arrowDelay[i]/10);
            }
            yield return new WaitForSeconds(0);
        }
    }
}