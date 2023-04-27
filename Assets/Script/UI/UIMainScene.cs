using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainScene : MonoSingleton<UIMainScene>
{
    public void StartBtn()
    {
        GameManager.Instance.LoadScene("Stage1");
    }

    public void SettingBtn()
    {

    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
