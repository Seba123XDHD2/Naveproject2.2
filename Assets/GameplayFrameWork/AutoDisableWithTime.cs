using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisableWithTime : MonoBehaviour
{
    public float autoDisableTime = 2f;

    private void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }

   
    IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(autoDisableTime);

        gameObject.SetActive(false);

    }
}
