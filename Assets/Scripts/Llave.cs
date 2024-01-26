using UnityEngine;
using UnityEngine.InputSystem;

public class Llave : MonoBehaviour
{
    public GameObject llavePrefab;  // Prefab de la llave
    private GameObject llaveRecogida;  // Referencia a la llave recogida

    private bool isPlayerNear = false;
    private bool isLlaveRecogida = false;

    void Start()
    {
        // Inicializar la llave recogida
        llaveRecogida = Instantiate(llavePrefab);
        llaveRecogida.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear)
        {
            if (!isLlaveRecogida && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                RecogerLlave();
            }
            else if (isLlaveRecogida && Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
            {
                SoltarLlave();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void RecogerLlave()
    {
        // Desactivar la llave original
        gameObject.SetActive(false);
        isLlaveRecogida = true;

        // Activar y posicionar la llave recogida en la mano del jugador
        llaveRecogida.SetActive(true);
        llaveRecogida.transform.position = GetPlayerHandPosition();
    }

    void SoltarLlave()
    {
        // Desactivar la llave recogida
        llaveRecogida.SetActive(false);
        isLlaveRecogida = false;

        // Activar la llave original en su posición original
        gameObject.SetActive(true);
    }

    Vector3 GetPlayerHandPosition()
    {
        // Puedes ajustar esto según la posición de la mano del jugador
        return transform.position + transform.up;
    }
}