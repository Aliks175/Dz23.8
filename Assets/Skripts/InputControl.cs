using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public static event Action<int> OnChange;
    public static event Action<float> OnScroll;

    private void Update()
    {
        ChekPress();
        CheckScroll();
    }

    /// <summary>
    /// Проверка нажата ли кнопка
    /// </summary>
    private void ChekPress()
    {
        if (Input.GetKeyDown(ConstInput.One))
        {
            OnChange?.Invoke(1);
        }
        else if (Input.GetKeyDown(ConstInput.Two))
        {
            OnChange?.Invoke(2);
        }
        else if (Input.GetKeyDown(ConstInput.Three))
        {
            OnChange?.Invoke(3);
        }
        else if (Input.GetKeyDown(ConstInput.Four))
        {
            OnChange?.Invoke(4);
        }
        else if (Input.GetKeyDown(ConstInput.Five))
        {
            OnChange?.Invoke(5);
        }
    }

    private void CheckScroll()
    {
        float directionScroll = Input.mouseScrollDelta.y;
        if (directionScroll != 0)
        {
            OnScroll?.Invoke(directionScroll);
            Debug.Log(directionScroll);
        }
    }
}
