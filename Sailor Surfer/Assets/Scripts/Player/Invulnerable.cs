using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    [HideInInspector] public bool isInvulnerable = false;

    [SerializeField] private float maxInvulnerableTimer = 0.5f;
    private float invulnerableTimer = 0.0f;

    void Update()
    {
        if (isInvulnerable)
        {
            if (invulnerableTimer < maxInvulnerableTimer)
            {
                invulnerableTimer += Time.deltaTime;
            }
            else
            {
                invulnerableTimer = 0.0f;
                isInvulnerable = false;
            }
        }
    }
}
