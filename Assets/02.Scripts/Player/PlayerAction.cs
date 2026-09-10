using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Inventory _inventory;
    private MousePointer _mousePointer;

    [SerializeField] private float _throwForce = 1f;
    private const float _dumpForce = 3f;
    
    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _mousePointer = GameObject.FindWithTag("MousePointer").GetComponent<MousePointer>();
    }
    
    private void Update()
    {
        // 1. 아이템 들고 있는지 체크 후 아이템 던지기
        bool isSelected = _inventory.IsSelected;
        if (Input.GetMouseButtonDown(1) && isSelected) ThrowItem();
        
        if (Input.GetKeyDown(KeyCode.T) && isSelected) DumpItem();
    }

    private void ThrowItem()
    {
        Debug.Log("던지자!");
        // 1. 현재 들고 있는 횃불 비활성화
        _inventory.EquipItem();
        
        // 2. 횃불 초기 위치 & 마우스 포인트 위치 계산
        Vector3 torchPosition = _inventory.EquippedTorch.transform.position;
        Vector3 mouseWorldPosition = _mousePointer.GetMouseWorldPosition();
        
        // 3. 방향 구하기
        Vector3 direction = (mouseWorldPosition - torchPosition).normalized;
        
        // 4. 횃불 생성 후 던지기
        GameObject torch = Instantiate(_inventory.ThrowableTorch, torchPosition, Quaternion.identity);

        Rigidbody2D rb = torch.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * _throwForce, ForceMode2D.Impulse);
        }
    }

    private void DumpItem()
    {
        Debug.Log($"버리자");
        
        // 1. 현재 들고 있는 횃불 비활성화
        _inventory.EquipItem();
        
        // 2. 횃불 초기 위치 & 마우스 포인트 위치 계산
        Vector3 torchPosition = _inventory.EquippedTorch.transform.position;
        Vector3 mouseWorldPosition = _mousePointer.GetMouseWorldPosition();
        
        // 3. 방향 구하기
        Vector3 direction = (mouseWorldPosition - torchPosition).normalized;
        
        // 4. 횃불 생성 후 던지기
        GameObject torch = Instantiate(_inventory.ThrowableTorch, torchPosition, Quaternion.identity);

        Rigidbody2D rb = torch.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * _dumpForce, ForceMode2D.Impulse);
        }
    }
}
