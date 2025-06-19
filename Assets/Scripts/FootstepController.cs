using UnityEngine;
using UnityEngine.UI;

public class FootstepController : MonoBehaviour
{
    [SerializeField] private Joystick joystick; // Ссылка на компонент джойстика
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private float walkSoundInterval = 0.5f; // Интервал между шагами
    [SerializeField] private float runThreshold = 0.7f; // Порог скорости для бега

    private float _stepTimer;
    private bool _isMoving;

    private void Update()
    {
        // Получаем вектор ввода от джойстика
        Vector2 moveDirection = joystick.Direction;

        // Проверяем, движется ли персонаж
        _isMoving = moveDirection.magnitude > 0.1f;

        if (_isMoving)
        {
            // Проверяем скорость для определения бега
            bool isRunning = moveDirection.magnitude > runThreshold;

            // Обновляем таймер
            _stepTimer -= Time.deltaTime;

            if (_stepTimer <= 0)
            {
                PlayFootstepSound();
                // Устанавливаем интервал в зависимости от скорости
                _stepTimer = isRunning ? walkSoundInterval * 0.7f : walkSoundInterval;
            }
        }
        else
        {
            // Сбрасываем таймер при остановке
            _stepTimer = 0;

        }
    }

    private void PlayFootstepSound()
    {
        if (footstepAudioSource != null && !footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Play();
        }
    }
}
