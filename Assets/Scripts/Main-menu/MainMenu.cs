using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("BattleSceneMobile");
    }
    public void OptionsEnterButton()
    {
        StartCoroutine(OptionsEnterButtonCor());
    }
    public void OptionsExitButton()
    {
        optionsMenu.SetActive(false);
    }
    private IEnumerator OptionsEnterButtonCor()
    {
        yield return new WaitForSeconds(0.2f);
        optionsMenu.SetActive(true);
    }
    public void QuitButtonPressed()
    {
        Application.Quit();
    }
    public void PlayAudioButtonPressing(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
