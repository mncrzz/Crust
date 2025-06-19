using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
public class PlayerController : MonoBehaviourPun
{
    [Header("PlayerController")]
    public Joystick joystick;
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    
    private CharacterController controller;
    private float gravity = -9.81f;
    private Vector3 velocity;
    [Header("PostProcessing")]
    public Camera cam;
    public Camera _cam;
    [Header("Photon")]
    public TMP_Text text_name;
    public PhotonView _photonView;
    public GameObject canvas;
    public GameObject _camera;
    public GameObject legs;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        text_name.text = _photonView.Owner.NickName; // устанавливаем никнейм
        if (!_photonView.IsMine) // если мы не локальный игрок то...
        {
            _camera.SetActive(false);
            canvas.SetActive(false);
            legs.SetActive(false);
        }
    }

    void Update()
    {
        //проверка на локального игрока
        if (!_photonView.IsMine) return;

        // Управление игроком
        HandleMovement();
        HandleJumpAndGravity();

        // Пост процессинг
        if(PlayerPrefs.GetInt("ps") == 1)
        {
            var cameraData = cam.GetUniversalAdditionalCameraData();
            var _cameraData = _cam.GetUniversalAdditionalCameraData();
            cameraData.renderPostProcessing = true;
            _cameraData.renderPostProcessing = true;
        }
        else
        {
            var cameraData = cam.GetUniversalAdditionalCameraData();
            var _cameraData = _cam.GetUniversalAdditionalCameraData();
            cameraData.renderPostProcessing = false;
            _cameraData.renderPostProcessing = false;
        }

    }

    void HandleMovement()
    {
        // Получаем ввод с джойстика
        Vector2 input = joystick.Direction;
        
        // Рассчитываем направление относительно камеры
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Создаем вектор движения
        Vector3 moveDirection = (cameraForward * input.y + cameraRight * input.x).normalized;
        
        // Двигаем персонажа
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void HandleJumpAndGravity()
    {
        // Проверка на земле
        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Применяем гравитацию
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void LeaveRoom() // выход из комнаты
    {
        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Lobby");
    }

    public void JumpButton()
    {
        if (!_photonView.IsMine) return;

        if(controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}