using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIThingy : MonoBehaviour
{
    public Animator transition;
    public float animationTime;

    public Slider health;

    public void OnClickStartButton()
    {
        StartCoroutine(TransitionLevels(2));
    }

    public void OnClickMainMenu()
    {
        StartCoroutine(TransitionLevels(0));
    }

    public void OnClickHelp()
    {
        StartCoroutine(TransitionLevels(1));
    }

    public void OnClickQuit()
    {
        Debug.Log("if you see this ur gay HAHAHAHAHAHAHAH");
        Application.Quit();
    }

    public void OnClickNextLevel()
    {
        StartCoroutine(TransitionLevels(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator TransitionLevels(int buildIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(animationTime);

        SceneManager.LoadScene(buildIndex);
    }

    private void Update()
    {
        
    }
}
