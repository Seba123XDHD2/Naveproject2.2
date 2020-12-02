using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class UIBulletCounter : SerializedMonoBehaviour
{
    public TextMeshProUGUI bulletCountText;
    int maxBullets;
    public Color normalColor=Color.blue;
    public Color dangerColor = Color.red;
    public Vector2 normalSize = Vector2.one;
    public Vector2 emptySize = new Vector2(1.5f,1.5f);

    private void OnDisable()
    {
        PlayerShipMain.OnBulletCountChange -= PlayerShipMain_OnBulletCountChange;
        PlayerShipMain.OnPlayerInitialize -= PlayerShipMain_OnPlayerInitialize;

    }

    private void OnEnable()
    {
        PlayerShipMain.OnBulletCountChange += PlayerShipMain_OnBulletCountChange;
        PlayerShipMain.OnPlayerInitialize += PlayerShipMain_OnPlayerInitialize;
    }

    private void PlayerShipMain_OnPlayerInitialize(int Param1)
    {
        maxBullets = Param1;
        bulletCountText.SetText(Param1.ToString());
        bulletCountText.transform.localScale = Vector2.one;
        bulletCountText.color = normalColor;
        percent = 1;

    }
    [ReadOnly]
    public float percent;
    private void PlayerShipMain_OnBulletCountChange(int bulletCount)
    {
        bulletCountText.SetText(bulletCount.ToString());
        bulletCountText.transform.localScale = Vector2.one;


        percent = (float)(bulletCount*1.0) / (float)maxBullets*1.0f ;

        bulletCountText.color = Color.Lerp(  dangerColor, normalColor,percent);

        
            bulletCountText.transform.DOPunchScale(Vector2.Lerp(emptySize,normalSize,percent), 0.1f);

    }
}
