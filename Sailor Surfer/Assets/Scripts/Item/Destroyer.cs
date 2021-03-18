using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private bool destroyable = true;

    public void Destroy(float t)
    {
        if(destroyable)
        Destroy(gameObject, t);
    }
}
