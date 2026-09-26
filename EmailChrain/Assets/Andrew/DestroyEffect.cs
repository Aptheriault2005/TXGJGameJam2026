using UnityEngine;

public abstract class DestroyEffect : ScriptableObject
{
    public abstract void Activate(Bullet bullet);
}