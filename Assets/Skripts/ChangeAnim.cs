using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string _activeAnimationName;
    private List<string> ArrayAnimationName;

    private void Start()
    {
        ArrayAnimationName  = new List<string>();
        FillList();
    }
    private void OnEnable()
    {
        InputControl.OnChange += Change;
    }

    private void OnDisable()
    {
        InputControl.OnChange -= Change;
    }

    private void FillList()
    {
        ArrayAnimationName.Add("Attack");
        ArrayAnimationName.Add("Death");
        ArrayAnimationName.Add("Walk");
        ArrayAnimationName.Add("Idle");
        ArrayAnimationName.Add("HitDamage");
    }

    private void Change(int index)
    {
        int nextIndex = index - 1;
        if (nextIndex > ArrayAnimationName.Count || nextIndex < 0) return;
        if (ArrayAnimationName[nextIndex] == _activeAnimationName) return;
        _activeAnimationName = ArrayAnimationName[nextIndex];
        animator.Play(_activeAnimationName);
    }
}
