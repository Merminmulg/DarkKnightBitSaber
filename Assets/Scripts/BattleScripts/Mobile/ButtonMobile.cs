using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMobile : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isActivate = false;
    public void ButtonClick()
    {
        if(!_isActivate) StartCoroutine(ButtonActivity());
    }
    public bool IsActivate()
    {
        return _isActivate;
    }
    private IEnumerator ButtonActivity()
    {
        _isActivate = true;
        yield return new WaitForSeconds(0.1f);
        _isActivate = false;
    }
}
