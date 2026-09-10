using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : Item
{
    private Light2D _light2D;

    [SerializeField] private float _baseIntensity = 1f;
	[SerializeField] private float _flickerSpeed = 1f;
	[SerializeField] private float _flickerAmount = 0.5f;

	private float BaseIntensity = 1.0f;
	
	
    private void Start()
    {
		_light2D = GetComponent<Light2D>();
    }

	private void Update()
	{
		if (_light2D == null) return;
		
		// 현재 시간에 속도를 곱하고 무작위 시작점을 더한다.
		// float currentTime = (Time.time * );

		// Mathf.PerlinNoise를 사용하여 불규칙하고 자연스러운 난수(0~1)를 생성
		float noise = Mathf.PerlinNoise(Time.time * _flickerSpeed, 0f);

		// 기본 강도에 노이즈 값을 더하여 빛의 강도를 매 프레임 조절
		_light2D.intensity = _baseIntensity + (noise * _flickerAmount);
	}
}
