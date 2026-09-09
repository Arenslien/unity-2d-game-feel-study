using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Player의 움직임에 대한 필드
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    private bool isGround = true;
    
    // 물리 작용을 위한 오브젝트 컴포넌트 클래스
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        Jump();
    }

    private void Move()
    {
        // Todo: 물리제어의 일관성
        // transform.Translate: 좌표 강제 이동 방식의 문제점
        // 추후 장애물과 충돌 시 떨림 현상 발생
        // 따라서 Rigidbody로 통제하는 코드로 수정
        // _rigidbody2D.velocity = new Vector2(h * _speed, _rigidbody2D.velocity.y);
        
        float h = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(h, 0);
        
        transform.Translate(_speed * Time.deltaTime * direction);
    }

    private void Jump()
    {
        // Todo: 땅 위치와 플레이어가 붙어 있는지 여부 확인하는 로직 추가
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump!");
        }
    }
}
