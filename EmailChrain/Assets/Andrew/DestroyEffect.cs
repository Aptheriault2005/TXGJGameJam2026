using UnityEngine;

public abstract class DestroyEffect : ScriptableObject
{
    public abstract void Activate(Vector3 position);
}