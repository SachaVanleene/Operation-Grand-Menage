using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {



    static public GameObject[] FindComponentInChildWithTag(this GameObject parent, string tag)
    {
        GameObject[] resu = new GameObject[3];
        int i = 0;
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                resu[i] = tr.gameObject;
                i += 1;
            }
        }
        return resu;
    }
}
