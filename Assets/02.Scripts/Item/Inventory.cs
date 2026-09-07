using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    private bool _isSelected = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem();
        }
    }

    private void EquipItem()
    {
        _isSelected = !_isSelected;
        _items[0].SetActive(_isSelected);
    }
}
