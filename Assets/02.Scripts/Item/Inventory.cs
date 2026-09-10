using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] _equippedItems;
    [SerializeField] private GameObject[] _originItemPrefabs;
    
    // Todo: 배열 기반 아이템 선택 방식으로 구현해야 함.
    private bool _isSelected = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem();
        }
    }

    public void EquipItem()
    {
        _isSelected = !_isSelected;
        _equippedItems[0].SetActive(_isSelected);
    }

    public bool IsSelected => _isSelected;
    public GameObject EquippedTorch => _equippedItems[0];
    public GameObject ThrowableTorch => _originItemPrefabs[0];
}
