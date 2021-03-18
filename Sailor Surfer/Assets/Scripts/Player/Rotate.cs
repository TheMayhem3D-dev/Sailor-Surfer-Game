using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float targetAngle = 0f;
    [SerializeField] private float rotationSpeed = 1.0f;

    public IEnumerator RotateNow()
    {
        float currentAngle = 0f;
        while (true)
        {
            float step = rotationSpeed * Time.deltaTime;

            if (currentAngle + step > targetAngle)
            {
                step = targetAngle - currentAngle;
                transform.Rotate(Vector3.up, step);
                break;
            }

            currentAngle += step;
            transform.Rotate(Vector3.up, step);
            yield return null;
        }
    }
}
