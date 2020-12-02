using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class PlayerShipMain : SerializedMonoBehaviour
{
    CharacterTopDownMovement characterTopDownMovement;

    public int maxBullets = 10;

    ProjectileSpawner projectileSpawner;
    [ReadOnly]
    public int currentBullets = 10;

    public UnityEvent OnFireSucceded, OnFireFailed,OnBulletRecover;


    public static event FNotify_1Params<int> OnBulletCountChange;
    public static event FNotify_1Params<int> OnPlayerInitialize;

    private void Awake()
    {
        projectileSpawner = GetComponent<ProjectileSpawner>();
        characterTopDownMovement = GetComponent<CharacterTopDownMovement>();

    }
    private void Start()
    {
        OnPlayerInitialize?.Invoke(maxBullets);
    }

    public void TryToShoot()
    {
        if (currentBullets <= 0)
        {
            OnBulletCountChange?.Invoke(currentBullets);
            OnFireFailed.Invoke();
            return;
        }
        currentBullets--;

        projectileSpawner.SpawnProjectile();
        OnBulletCountChange?.Invoke(currentBullets);
        OnFireSucceded?.Invoke();
    }
    void RecoverBullet(PlayerBulletBouncer bullet)
    {
        if (bullet == null) return;
        if (!bullet.TryToRecover()) return;
        OnBulletRecover.Invoke();
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

    public void TryToMoveTowards(Vector2 moveDirection)
    {
         
        characterTopDownMovement.AddMovementInput(moveDirection);
    }

   
}
