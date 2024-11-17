using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private List<GameObject> _weapons;
    private GameObject _activeGameObject;
    private int index;
    private int WeaponIndex
    {
        get
        {
            return index;
        }
        set
        {
            if (value > _weapons.Count-1)
            {
                index = _weapons.Count-1;
            }
            else if (value < 0)
            {
                index = 0;
            }
            else { index = value; }
        }
    }

    private void Start()
    {
        WeaponIndex = 0;
        _activeGameObject = _weapons[WeaponIndex];
        _activeGameObject.SetActive(true);

    }

    private void OnEnable()
    {
        InputControl.OnScroll += Change;
    }

    private void OnDisable()
    {
        InputControl.OnScroll -= Change;
    }

    private void Change(float mod)
    {
        if (mod > 0)
        {
            WeaponIndex++;
        }
        else
        {
            WeaponIndex--;
        }
        if (_weapons[WeaponIndex] == _activeGameObject) return;
        _activeGameObject.SetActive(false);
        _activeGameObject = _weapons[WeaponIndex];
        _activeGameObject.SetActive(true);


    }
}
