using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : Item
{
    private Light2D _light2D;

    // UI에서 조절할 튜닝 파라미터
    [SerializeField] private float _baseIntensity = 1f;
    [SerializeField] private float _baseRadius = 5.0f;
    [SerializeField] private float _flickerSpeed = 3.0f;
    [SerializeField] private float _noiseAmplitude = 0.5f;
    
    // [SerializeField] private float _flickerSpeed = 1f;
	// [SerializeField] private float _flickerAmount = 0.5f;

	private float _randomTimeOffset;
	
	// private float BaseIntensity = 1.0f;

	private void Awake()
	{
		_light2D = GetComponent<Light2D>();
		_randomTimeOffset = Random.Range(0f, 100f);
	}

	private void Update()
	{
		if (_light2D == null) return;
		
		// 현재 시간에 속도를 곱하고 무작위 시작점을 더한다.
		float currentTime = (Time.time * _flickerSpeed) + _randomTimeOffset;
		
		// 1. 큰 흐름의 부드럴운 바람 (저주파 노이즈)
		float mainNoise = Mathf.PerlinNoise(currentTime, 0f) - 0.5f;
		
		// 2. 자잘하게 떨리는 불티 (고주파 노이즈)
		// 시간을 2.5배 빠르게 흘려보내 잘게 쪼개진 파동을 만든다.
		float subNoise = Mathf.PerlinNoise(currentTime * 2.5f, 50f) - 0.5f;
		
		// 3. 두 노이즈의 합성
		float combinedNoise = mainNoise + (subNoise * 0.3f);
		
		// 4. 최종 값 적용 (음수 방지로 Mathf.Max 사용)
		_light2D.intensity = Mathf.Max(0.1f, _baseIntensity + (combinedNoise + _noiseAmplitude));
		_light2D.pointLightOuterRadius = Mathf.Max(0.5f, _baseRadius + (combinedNoise * _noiseAmplitude));

		// // 현재 시간에 속도를 곱하고 무작위 시작점을 더한다.
		// // float currentTime = (Time.time * );
		//
		// // Mathf.PerlinNoise를 사용하여 불규칙하고 자연스러운 난수(0~1)를 생성
		// float noise = Mathf.PerlinNoise(Time.time * _flickerSpeed, 0f);
		//
		// // 기본 강도에 노이즈 값을 더하여 빛의 강도를 매 프레임 조절
		// _light2D.intensity = _baseIntensity + (noise * _flickerAmount);
	}
}
