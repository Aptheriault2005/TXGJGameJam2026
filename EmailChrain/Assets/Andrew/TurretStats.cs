using UnityEngine;

[CreateAssetMenu(fileName = "TurretStats", menuName = "Scriptable Objects/TurretStats")]
public class TurretStats : ScriptableObject
{
    public ProjectileStats ProjectileStats;
    public float FireRate;
    public int ProjectileSpray;
}
