using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class EnemyBattleController : MonoBehaviour, IEnemyBattleController
{

    private List<GameObject> arrowsList;

    private Vector3 _arrowSpawnZonePosition;
    public delegate void IsRightButtonPressedDelegate(string buttonDirection);
    public event System.Action<bool, int> OnArrowDestroyed;
    private bool _deathAllowed;
    //True if killed by using arrow
    private void Start()
    {
        Debug.Log("SkeletBattleSuccess");
        arrowsList = new List<GameObject>();
    }
    private void Awake()
    {
        _arrowSpawnZonePosition = GameObject.FindGameObjectWithTag("ArrowSpawnZone").transform.position;
        _deathAllowed = false;
    }
    public void ButtonsSubscibe(IsRightButtonPressedDelegate buttonController)
    {

    }
    public void SpawnArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow, List<float> arrowDelay, List<int> arrowOrder)
    {
        StartCoroutine(InstantiateArrows(leftArrow, rightArrow, upArrow, downArrow, arrowDelay, arrowOrder));
    }
    public void SpawnArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow, List<float> arrowDelay)
    {
        List<int> arrowOrder = new List<int>();
        for (int i = 0; i<arrowDelay.Count; i++)
        {
            arrowOrder.Add(Random.Range(0, 4));
        }
        StartCoroutine(InstantiateArrows(leftArrow, rightArrow, upArrow, downArrow, arrowDelay, arrowOrder));
    }


//Battle method start the battle scene by instintiate the arrows
public IEnumerator InstantiateArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow, List<float> arrowDelay, List<int> arrowOrder)
    { 
        for (int i = 0; i < arrowOrder.Count; i++)
        {
            if (arrowDelay[i] >= 0)
            {
                yield return new WaitForSeconds(arrowDelay[i]/10);
            }
            if (arrowOrder[i] >= 0)
                {
                switch (arrowOrder[i])
                {
                    case 0:
                        //Instantiate(upArrow, _arrowsSpawnZone.transform);
                        arrowsList.Add(Instantiate(upArrow, _arrowSpawnZonePosition, upArrow.transform.rotation));
                        break;
                    case 1:
                        arrowsList.Add(Instantiate(downArrow, _arrowSpawnZonePosition, downArrow.transform.rotation));
                        break;
                    case 2:
                        arrowsList.Add(Instantiate(leftArrow, _arrowSpawnZonePosition, Quaternion.identity));
                        break;
                    case 3:
                        arrowsList.Add(Instantiate(rightArrow, _arrowSpawnZonePosition, Quaternion.identity));
                        break;
                }
                arrowsList[i].GetComponent<Arrow>().OnStatusChanged += DestroiedArrow;
            }
        }
        _deathAllowed = true;
        Debug.Log(arrowsList.Count);
    }


    public void DetectWinBattle(Enemy enemy)
    {
        try
        {
            if (arrowsList[arrowsList.Count - 1] == null && _deathAllowed)
            {
                StartCoroutine(DestroyEnemy(enemy));
            }
        }
        catch
        {
            
        }
    }
    private IEnumerator DestroyEnemy(Enemy enemy)
    {
        enemy.animator.SetBool("Death", true);
        yield return new WaitForSeconds(2f);
        Destroy(enemy.gameObject);
    }
    public void DestroiedArrow(bool status, int keyNum)
    {
        OnArrowDestroyed.Invoke(status, keyNum);   
    }
}
