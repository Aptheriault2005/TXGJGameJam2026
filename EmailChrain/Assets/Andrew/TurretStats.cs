using UnityEngine;

[CreateAssetMenu(fileName = "TurretStats", menuName = "Scriptable Objects/TurretStats")]
public class TurretStats : ScriptableObject
{
    public ProjectileStats ProjectileStats;
    public float FireRate;
    public int ProjectileSpray;

    public TurretStats Copy()
    {
        TurretStats copy = CreateInstance<TurretStats>();
        copy.ProjectileStats = ProjectileStats;
        copy.FireRate = FireRate;
        copy.ProjectileSpray = ProjectileSpray;
        return copy;
    }
}
