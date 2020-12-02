using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;


 
[System.Serializable]
public class AxisMove : UnityEvent<Vector2> { };
 
 
public class ButtonSetup
{
    public string buttonName;
    public UnityEvent OnButtonDown;

}
 

    public class PlayerControllerInput : SerializedMonoBehaviour
{
    public AxisMove OnAxisMove;
    Vector2 targetDirection=Vector2.zero;

    [Header("Buttons")]
    public ButtonSetup[] buttons;

    void ReadInput()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");

        targetDirection.x = horizontalValue;
        targetDirection.y = verticalValue;

        OnAxisMove?.Invoke(targetDirection);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (Input.GetButtonDown(buttons[i].buttonName))
            {
                buttons[i].OnButtonDown.Invoke();
            }
        }
      
         
    }
    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }
}
 