using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonUI : MonoBehaviour
{
    private bool isPaused = false;

    private void Start()
    {
        if (Finder.FindGameObject("Pause") != null)
        {
            GameObject obj = Finder.FindGameObject("Pause");
            obj.GetComponent<Button>().onClick.AddListener(() => Pause());
        }
    }

    private void  Pause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // pause the game
        }
        else
        {
            Time.timeScale = 1; // resume the game
        }
    }


}
