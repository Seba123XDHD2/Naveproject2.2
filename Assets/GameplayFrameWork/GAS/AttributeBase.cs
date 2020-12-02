using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AttributeBase : MonoBehaviour
{
    public float baseValue=1;
    public float minValue = 0;
    private float currentValue;

    public FUnityNotify_1Params  OnAttributeChange;
    public FUnityNotify_2Params OnAttributeChangeWithPercent;

    private void OnEnable()
    {
        currentValue = baseValue;

    }
    // Start is called before the first frame update
    void Start()
    {
     }

    public void InitializeAttribute(float NewBaseValue)
    {
        baseValue=currentValue = NewBaseValue;
        currentValue = Mathf.Clamp(currentValue, minValue, baseValue);
        NotifyUI();

    }
    public void SetValue(float NewValue)
    {
        currentValue = NewValue;
        currentValue = Mathf.Clamp(currentValue, minValue, baseValue);
        NotifyUI();

    }
    public void AddToValue(float NewValue)
    {
        //clamp mantiene valores entre el maximo y el minimo
        currentValue += NewValue;
        currentValue = Mathf.Clamp(currentValue, minValue, baseValue);
        NotifyUI();
    }
    public void SubtractToValue(float NewValue)
    {
        AddToValue(-NewValue);

    }

    private void NotifyUI()
    {
        OnAttributeChange.Invoke(currentValue);
        OnAttributeChangeWithPercent.Invoke(currentValue,currentValue/baseValue) ;

    }



}
