using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIThingy : MonoBehaviour
{
    public Animator transition;
    public float animationTime;

    public void OnClickStartButton()
    {
        StartCoroutine(TransitionLevels(1));
    }

    public void OnClickMainMenu()
    {
        StartCoroutine(TransitionLevels(0));
    }

    public void OnClickHelp()
    {
        StartCoroutine(TransitionLevels(7));
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public IEnumerator TransitionLevels(int buildIndex)
    {
        transition.SetTrigger("Win");

        yield return new WaitForSeconds(animationTime);

        SceneManager.LoadScene(buildIndex);
    }
    public void OnClickCredit()
    {
        StartCoroutine(TransitionLevels(8));
    }
}
