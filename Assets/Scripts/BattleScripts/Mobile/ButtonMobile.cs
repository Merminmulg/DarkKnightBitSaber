using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMobile : MonoBehaviour
{
    [SerializeField] private Sprite _firstForm;
    [SerializeField] private Sprite _secondForm;
    [SerializeField] private Image _image;
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
        _image.sprite = _secondForm;
        yield return new WaitForSeconds(0.1f);
        _image.sprite = _firstForm;
        _isActivate = false;
    }
}
