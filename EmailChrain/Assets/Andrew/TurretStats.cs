using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretStats", menuName = "Scriptable Objects/TurretStats")]
public class TurretStats : ScriptableObject
{
    public string Name;
    public ProjectileStats ProjectileStats;
    public float FireRate;
    public int ProjectileSpray;
    public List<TurretStats> UpgradePaths = new();

    public TurretStats Copy()
    {
        TurretStats copy = CreateInstance<TurretStats>();
        copy.Name = Name;
        copy.ProjectileStats = ProjectileStats;
        copy.FireRate = FireRate;
        copy.ProjectileSpray = ProjectileSpray;
        return copy;
    }
}
