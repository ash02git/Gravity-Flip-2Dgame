using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentType : MonoBehaviour
{
    //segment is referred to a chunk of the play space that includes the borders and obstacles
    //depending on the length of the chunk - small and large
    public SegmentEnum segmentType;
    public float segmentOffset;

    private void Awake()
    {
        //segment offsets are fixed values due to the way i created them
        if (segmentType == SegmentEnum.small)
            segmentOffset = 166.0f;
        else if (segmentType == SegmentEnum.large)
            segmentOffset = 268.0f;
    }

    public float GetOffset()
    {
        return segmentOffset;
    }
}

[Serializable]
public enum SegmentEnum
{
    small,
    large
}

