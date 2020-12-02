using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerShipMain : SerializedMonoBehaviour
{
    public int maxBullets = 10;

    ProjectileSpawner projectileSpawner;
    [ReadOnly]
    public int currentBullets = 10;

    public static event FNotify_1Params<int> OnBulletCountChange;
    public static event FNotify_1Params<int> OnPlayerInitialize;

    private void Awake()
    {
        projectileSpawner = GetComponent<ProjectileSpawner>();

    }
    private void Start()
    {
        OnPlayerInitialize?.Invoke(maxBullets);
    }
    public void TryToShoot()
    {
        if (currentBullets <= 0) return;
        currentBullets--;
        projectileSpawner.SpawnProjectile();
        OnBulletCountChange?.Invoke(currentBullets);
    }
    void RecoverBullet(PlayerBulletBouncer bullet)
    {
        if (bullet == null) return;
        if (!bullet.TryToRecover()) return;
     
        currentBullets++;
        OnBulletCountChange?.Invoke(currentBullets);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BulletPlayer"))
        {
            RecoverBullet(collision.gameObject.GetComponent<PlayerBulletBouncer>());
        }
    }

   
}
