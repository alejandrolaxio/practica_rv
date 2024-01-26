using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float rotationSpeed = 200.0f;  // Ajusta este valor para controlar la velocidad de giro

    private Vector2 lookInput;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!target)
            return;

        lookInput = Mouse.current.delta.ReadValue();

        // Aplicar rotaci�n basada en la posici�n del rat�n en ambos ejes
        float rotationX = transform.eulerAngles.x - lookInput.y * rotationSpeed * Time.deltaTime;
        float rotationY = transform.eulerAngles.y + lookInput.x * rotationSpeed * Time.deltaTime;

        // Limitar la rotaci�n vertical entre -90 y 90 grados
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Aplicar rotaci�n suavizada a la c�mara
        Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);

        // Calcular la posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position - transform.forward * distance + Vector3.up * height;

        // Aplicar posici�n suavizada a la c�mara
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.1f);
    }
}