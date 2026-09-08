using UnityEngine;

public class MousePointer : MonoBehaviour
{
    // 성능 최적화를 위해 메인 카메라 캐싱
    private Camera _mainCamera;
    
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        // 1. 유리창에 짚은 손가락 위치
        Vector3 mouseScreenPosition = Input.mousePosition;
        Debug.Log(mouseScreenPosition);

        // 2. 유리창에서 실제 게임 오브젝트가 있는 위치까지의 깊이(z) 보정
        mouseScreenPosition.z = Mathf.Abs(_mainCamera.transform.position.z);
        
        // 3. 월드 좌표로의 변환
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        Debug.Log($"월드 좌표: {mouseWorldPosition}");
        
        // 4. 실제 게임 오브젝트들이 있는 위치의 Z로 고정
        mouseWorldPosition.z = 0f;
        
        transform.position = mouseWorldPosition;
    }
}
