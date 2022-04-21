using System.Collections;
using UnityEngine;

internal interface IEnemyBattleController
{
    public event System.Action<bool> OnArrowDestroyed;
    public IEnumerator SpawnArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow);
    public void DetectWinBattle(GameObject enemy);
}