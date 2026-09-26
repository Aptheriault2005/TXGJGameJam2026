using UnityEngine;

[CreateAssetMenu(fileName = "TurretStats", menuName = "Scriptable Objects/TurretStats")]
public class TurretStats : ScriptableObject
{
    public BulletStats BulletStats;
    public float FireRate;
    public int BulletSpray;
}
