using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BorderLimit
{
    LIMIT_X,
    LIMIT_Z,
    LIMIT_BOTH
}

public class Turn : MonoBehaviour
{
    [SerializeField] private float turnAngle;
    public float TurnAngle { get => turnAngle; }

    [SerializeField] private BorderLimit borderSideLimit;
    public BorderLimit BorderSideLimit { get => borderSideLimit; }
    
    [SerializeField] private float minLimitX = -2f;
    [SerializeField] private float maxLimitX = 2f;

    [SerializeField] private float minLimitZ = -2f;
    [SerializeField] private float maxLimitZ = 2f;

    public float MinLimitX { get => minLimitX; }
    public float MaxLimitX { get => maxLimitX; }
    public float MinLimitZ { get => minLimitZ; }
    public float MaxLimitZ { get => maxLimitZ; }
}
