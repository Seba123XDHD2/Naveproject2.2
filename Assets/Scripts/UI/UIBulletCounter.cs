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
        bulletCountText.transform.DOPunchScale(Vector2.one * 1.1f, 0.2f);
        percent = (float)(bulletCount*1.0) / (float)maxBullets*1.0f ;

        bulletCountText.color = Color.Lerp(  dangerColor, normalColor,percent);


    }
}
