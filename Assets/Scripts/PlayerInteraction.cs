using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 2f;

    void Update()
    {
        bool interactPressed = Mouse.current != null ? Mouse.current.leftButton.wasPressedThisFrame : false;

        if (interactPressed)
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        RaycastHit hit;

        // Ajusta la capa "Llave" en el siguiente raycast
        int layerMask = 1 << LayerMask.NameToLayer("Llave");

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, layerMask))
        {
            GameObject interactedObject = hit.collider.gameObject;

            if (interactedObject.CompareTag("Llave"))
            {
                RecogerLlave(interactedObject);
            }
        }
    }

    void RecogerLlave(GameObject llaveObject)
    {
        // Puedes personalizar esta función según tus necesidades
        Debug.Log("Llave Recogida");
        llaveObject.SetActive(false);
    }
}