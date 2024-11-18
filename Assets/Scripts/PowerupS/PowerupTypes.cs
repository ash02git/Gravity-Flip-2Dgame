using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tile;

public class PowerupTypes : MonoBehaviour
{
    public PowerupType poweruptype;

    public PowerupType GetPowerupType()
    {
        return poweruptype;
    }
}

[Serializable]
public enum PowerupType
{
    FieldOfView,
    GravityReducer,
    GravityIncreaser,
    ScoreMultiplier,
    SizeReducer,
    HealthIncrement
}

