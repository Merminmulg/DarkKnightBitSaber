using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
class SkeletBattleController : MonoBehaviour, IEnemyBattleController
{
    [SerializeField] private List<float> _arrowDelay;
    [SerializeField] private List<int> _arrowOrder;
    private Spawners _spawner;
    private List<GameObject> _arrowsList;
    private Vector3 _arrowSpawnZonePosition;

    public event System.Action<bool> OnArrowDestroyed;
    //True if killed by using arrow
    private IEnumerator<bool> _killedByArrowTouch;
    private void Start()
    {
        Debug.Log("SkeletBattleSuccess");
        _arrowsList = new List<GameObject>(_arrowOrder.Count);
    }
    private void Awake()
    {
        _arrowSpawnZonePosition = GameObject.FindGameObjectWithTag("ArrowSpawnZone").transform.position;
    }
    //Battle method start the battle scene by instintiate the arrows
    public IEnumerator SpawnArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow)
    { 
        for (int i = 0; i < _arrowOrder.Count; i++)
        {
            if (_arrowDelay[i] >= 0)
            {
                yield return new WaitForSeconds(_arrowDelay[i]/10);
            }
            if (_arrowOrder[i] >= 0)
                {
                switch (_arrowOrder[i])
                {
                    case 0:
                        //Instantiate(upArrow, _arrowsSpawnZone.transform);
                        _arrowsList.Add(Instantiate(upArrow, _arrowSpawnZonePosition, upArrow.transform.rotation));
                        _arrowsList[i].GetComponent<Arrow>().OnStatusChanged += MissingArrow;
                        break;
                    case 1:
                        _arrowsList.Add(Instantiate(downArrow, _arrowSpawnZonePosition, downArrow.transform.rotation));
                        _arrowsList[i].GetComponent<Arrow>().OnStatusChanged += MissingArrow;
                        break;
                    case 2:
                        _arrowsList.Add(Instantiate(leftArrow, _arrowSpawnZonePosition, Quaternion.identity));
                        _arrowsList[i].GetComponent<Arrow>().OnStatusChanged += MissingArrow;
                        break;
                    case 3:
                        _arrowsList.Add(Instantiate(rightArrow, _arrowSpawnZonePosition, Quaternion.identity));
                        _arrowsList[i].GetComponent<Arrow>().OnStatusChanged += MissingArrow;
                        break;
                }
            }
        }
        Debug.Log(_arrowsList.Count);
    }
    public void DetectWinBattle(GameObject enemy)
    {
        try
        {
            if (_arrowsList[_arrowsList.Count - 1] == null)
            {
                Destroy(enemy);
            }
        }
        catch
        {
            
        }
    }
    public void MissingArrow(bool status)
    {
        OnArrowDestroyed.Invoke(status);   
    }
}
