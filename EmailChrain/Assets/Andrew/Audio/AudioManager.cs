using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bulletSFX;
    public AudioSource missileSFX;
    public AudioSource explosionSFX;
    public AudioSource teslaSFX;
    public AudioSource enemyHurtSFX;
    public AudioSource enemyShootSFX;
    public AudioSource phisherSFX;
    public AudioSource bugSFX;

    private void Awake()
    {
        instance = this;
    }

    public static void PlayBulletSFX()
    {
        instance.bulletSFX.Play();
    }

    public static void PlayMissileSFX()
    {
        instance.missileSFX.Play();
    }
    
    public static void PlayExplosionSFX()
    {
        instance.explosionSFX.Play();
    }
    
    public static void PlayTeslaSFX()
    {
        instance.teslaSFX.Play();
    }
    
    public static void PlayEnemyHurtSFX()
    {
        instance.teslaSFX.Play();
    }
    
    public static void PlayEnemyShootSFX()
    {
        instance.teslaSFX.Play();
    }

    public static void PlayPhisherSFX()
    {
        instance.phisherSFX.Play();
    }
    
    public static void PlayBugSFX()
    {
        instance.bugSFX.Play();
    }
}
