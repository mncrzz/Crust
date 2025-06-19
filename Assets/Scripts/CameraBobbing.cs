using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    [Header("Bobbing Settings")]
    [SerializeField] private float bobbingSpeed = 14f;       // Частота покачивания
    [SerializeField] private float bobbingAmount = 0.05f;   // Интенсивность эффекта
    [SerializeField] private float midpointOffset = 1.6f;   // Базовая высота камеры

    [Header("References")]
    [SerializeField] private Transform cameraTransform;     // Ссылка на трансформ камеры
    public FixedJoystick fixedJoystick;
    private float timer = 0;
    private float defaultYPos;
    private bool isMoving;
    public GameObject legs;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = GetComponent<Transform>();

        defaultYPos = cameraTransform.localPosition.y;
    }

    void Update()
    {
        // Проверка ввода джойстика
        Vector2 input = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);
        isMoving = input.magnitude > 0.1f;

        HandleBobbingEffect();
    }

    void HandleBobbingEffect()
    {
        if (isMoving)
        {
            // Анимация покачивания
            timer += Time.deltaTime * bobbingSpeed;
            float waveSlice = Mathf.Sin(timer);
            float verticalOffset = waveSlice * bobbingAmount;

            Vector3 localPos = cameraTransform.localPosition;
            localPos.y = defaultYPos + verticalOffset;
            cameraTransform.localPosition = localPos;
            legs.GetComponent<Animator>().SetTrigger("Walking");
        }
        else
        {
            // Плавный возврат в исходное положение
            timer = 0;
            Vector3 localPos = cameraTransform.localPosition;
            localPos.y = Mathf.Lerp(localPos.y, defaultYPos, Time.deltaTime * bobbingSpeed);
            cameraTransform.localPosition = localPos;
        }
    }
}
