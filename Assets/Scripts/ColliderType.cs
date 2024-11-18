using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderType:MonoBehaviour
{
    public ColliderEnum colliderType;

    public ColliderEnum GetColliderType()
    {
        return colliderType;
    }
}
[Serializable]
public enum ColliderEnum
{
    Spike,
    Collectible,
    Powerup,
    SegmentEnd,
    OutOfBorder
}

