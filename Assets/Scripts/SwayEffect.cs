using UnityEngine;

public class SwayEffect : MonoBehaviour
{
    [Header("Position Sway")]
    public float swayAmount = 0.02f;    // Сила смещения
    public float maxSwayAmount = 0.06f; // Максимальное смещение
    public float swaySmoothness = 4f;   // Плавность смещения
    public FixedTouchField touchField;

    [Header("Rotation Sway")]
    public float rotationSwayAmount = 2f;   // Сила поворота
    public float maxRotationSway = 5f;      // Максимальный поворот
    public float rotationSmoothness = 8f;   // Плавность поворота

    private Vector3 initialPosition;   // Начальная позиция объекта
    private Quaternion initialRotation; // Начальный поворот объекта
    private Vector2 mouseDelta;        // Изменение позиции касания/мыши

    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (touchField != null)
        {
            mouseDelta = touchField.TouchDist;
        }

        ApplyPositionSway();
        ApplyRotationSway();
    }

    private void ApplyPositionSway()
    {
        // Вычисляем смещение на основе движения мыши/тача
        float moveX = Mathf.Clamp(-mouseDelta.x * swayAmount, -maxSwayAmount, maxSwayAmount);
        float moveY = Mathf.Clamp(-mouseDelta.y * swayAmount, -maxSwayAmount, maxSwayAmount);

        // Плавно двигаем объект
        Vector3 targetPosition = new Vector3(moveX, moveY, 0);
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            initialPosition + targetPosition,
            Time.deltaTime * swaySmoothness
        );
    }

    private void ApplyRotationSway()
    {
        // Вычисляем поворот на основе движения мыши/тача
        float tiltY = Mathf.Clamp(mouseDelta.x * rotationSwayAmount, -maxRotationSway, maxRotationSway);
        float tiltX = Mathf.Clamp(mouseDelta.y * rotationSwayAmount, -maxRotationSway, maxRotationSway);

        // Плавно поворачиваем объект
        Quaternion targetRotation = Quaternion.Euler(
            initialRotation.eulerAngles.x - tiltX,
            initialRotation.eulerAngles.y + tiltY,
            initialRotation.eulerAngles.z
        );

        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * rotationSmoothness
        );
    }
}
