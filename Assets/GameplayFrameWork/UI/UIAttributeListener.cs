using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UIAttributeListener : SerializedMonoBehaviour
{
    public TextMeshProUGUI attributeText;
    public Image percentBarFill;

    public bool TransformFloatToInt = true;
    private string textToDisplay;
    public void SetTextValue(float Value)
    {
        if (TransformFloatToInt)
            textToDisplay = Mathf.RoundToInt(Value).ToString();
        else
            textToDisplay = Value.ToString();

        attributeText?.SetText(textToDisplay);

    }
    public void SetTextValueWithPercent(float Value,float percent)
    {
        SetTextValue(Value);

        if(percentBarFill!=null)
        percentBarFill.fillAmount=percent;
    }


}
