using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Finder
{
    public static GameObject FindGameObject(string target)
    {
        GameObject obj;
        if (obj = GameObject.Find(target))
        {
            return obj;
        }

        return null;
    }
}
