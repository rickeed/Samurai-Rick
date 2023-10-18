using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform targetsParent;
    private List<Transform> targets;
    private int currentTargetIndex;
    private bool isFirstInput;
    private Transform ignoredTarget;
    public Animator playerAnim;

    public bool lookright = true;
    public bool lookleft = false;

    void Start()
    {
        targets = new List<Transform>();
        foreach (Transform child in targetsParent)
        {
            targets.Add(child);
        }
        SortTargetsByPosition();
        currentTargetIndex = 0;
        isFirstInput = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)&& lookleft)
        {
            MoveToPreviousTarget();
        }
        else if (Input.GetKeyDown(KeyCode.D) && lookright)
        {
            MoveToNextTarget();
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if(isFirstInput) 
            {
                isFirstInput = false;
                Invoke("RefreshTargets", 0.2f);
            }
        }
    }

    void SortTargetsByPosition()
    {
        targets.Sort((t1, t2) => t1.position.x.CompareTo(t2.position.x));
    }

    void MoveToNextTarget()
    {
        int nextTargetIndex = currentTargetIndex + 1;
        if (nextTargetIndex < targets.Count)
        {
            currentTargetIndex = nextTargetIndex;
            TeleportTo(targets[currentTargetIndex].position);
            ignoredTarget = targets[currentTargetIndex];
            
        }
        if (nextTargetIndex == targets.Count)
        {
            playerAnim.SetBool("TurnLeft", true);
            StartCoroutine(ResetLook());

        }
    }

    void MoveToPreviousTarget()
    {
        int previousTargetIndex = currentTargetIndex - 1;
        if (previousTargetIndex >= 0)
        {
            currentTargetIndex = previousTargetIndex;
            TeleportTo(targets[currentTargetIndex].position);
            ignoredTarget = targets[currentTargetIndex];
        }
        if (previousTargetIndex < 0)
        {
            playerAnim.SetBool("TurnLeft", false);
            StartCoroutine(ResetLookLeft());
        }


    }

    void TeleportTo(Vector2 targetPosition)
    {
        transform.position = targetPosition;
        

    }
    void RefreshTargets()
    {
        targets.Clear();
        float minDistance = float.MaxValue;
        foreach (Transform child in targetsParent)
        {
            float distance = Vector2.Distance(transform.position, child.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                ignoredTarget = child;
            }
            targets.Add(child);
        }
        SortTargetsByPosition();
        currentTargetIndex = 0;
    }
    IEnumerator ResetLook()
    {
        yield return new WaitForSeconds(0.2f);
        lookright = false;
        lookleft = true;
    }
    IEnumerator ResetLookLeft()
    {
        yield return new WaitForSeconds(0.2f);
        lookleft = false;
        lookright = true;
    }
    //void UpdateIgnoredTarget()
    //{
    //    float minDistance = float.MaxValue;
    //    Transform closestTarget = null;
    //    foreach (Transform target in targets)
    //    {
    //        float distance = Vector2.Distance(transform.position, target.position);
    //        if (distance < minDistance)
    //        {
    //            minDistance = distance;
    //            closestTarget = target;
    //        }
    //    }
    //    ignoredTarget = closestTarget;
    //}
}
