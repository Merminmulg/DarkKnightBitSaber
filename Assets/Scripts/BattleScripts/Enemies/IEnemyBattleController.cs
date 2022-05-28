using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public interface IEnemyBattleController
{
    public event System.Action<bool, int> OnArrowDestroyed;
    public delegate bool IsRightButtonPressedDelegate(string buttonDirection);
    public void SpawnArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow, List<float> arrowDelay, List<int> arrowOrder);
    public void SpawnArrows(GameObject leftArrow, GameObject rightArrow, GameObject upArrow, GameObject downArrow, List<float> arrowDelay);
    public void DetectWinBattle(Enemy enemy);
}