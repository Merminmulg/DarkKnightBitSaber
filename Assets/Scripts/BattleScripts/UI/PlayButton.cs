using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite _firstForm;
    [SerializeField] private Sprite _secondForm;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _pauseMenuUI;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnPlay()
    {
        StartCoroutine(ButtonActivity());
    }
    private IEnumerator ButtonActivity()
    {
        Time.timeScale = 1.0f;
        _image.sprite = _secondForm;
        yield return new WaitForSeconds(0.1f);
        _image.sprite = _firstForm;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
