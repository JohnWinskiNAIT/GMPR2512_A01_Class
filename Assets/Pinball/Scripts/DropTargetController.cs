using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

public class DropTargetController : MonoBehaviour
{
    [SerializeField] List<DropTarget> targetList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool reset = true;

        for (int i = 0; i < targetList.Count && reset == true; i++)
        {
            if (targetList[i].IsTargetActive())
            {
                reset = false;
            }
        }
        // Foreach should only be used if you are going to check every element
        //foreach (var target in targetList)
        //{
        //    if (target.IsTargetActive())
        //    {
        //        reset = false;
        //    }
        //}

        if (reset)
        {
            foreach (DropTarget target in targetList)
            {
                target.ResetTarget(2.0f);
            }
        }
    }
}
