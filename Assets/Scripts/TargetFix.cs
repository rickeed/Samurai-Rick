using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFix : MonoBehaviour
{
    public GameObject firstTarget;
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            firstTarget.transform.SetParent(transform);
        }
    }
}
