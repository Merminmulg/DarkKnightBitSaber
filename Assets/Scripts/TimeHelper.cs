using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeHelper
{
    /// <summary>
    /// <c>TimeDelay</c>: Wait for a time (delay/10)
    /// </summary>
    /// <param name="delay">integer delay</param>
    public static IEnumerator TimeDelay(int delay)
    {
        yield return new WaitForSeconds(delay/10);
    }
}
