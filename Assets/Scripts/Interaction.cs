using UnityEngine;
using UnityEngine.TerrainTools;

public class Interaction : MonoBehaviour
{
    [SerializeField] float maxInteractRange;
    [SerializeField] Transform holdPosition;
    [SerializeField] float throwForce;
    [SerializeField] Camera cam;

    // Picked Object
    GameObject pickedObject;
    Rigidbody pickedRigidbody;

    // Bullet
    [SerializeField] GameObject bullet;

    // Paint Object
    GameObject paintObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowObject();
            Paint();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (pickedObject == null)
            {
                HandleInteract();
            }
            else
            {
                DropObject();
            }
        }
    }

    void HandleInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxInteractRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                TryPickUp(hit);
            }

            if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactable.Interact();
            }
        }


    }

    void TryPickUp(RaycastHit hit)
    {
        pickedObject = hit.collider.gameObject;
        pickedRigidbody = pickedObject.GetComponent<Rigidbody>();

        if (pickedRigidbody != null)
        {
            pickedRigidbody.isKinematic = true;
            pickedObject.transform.position = holdPosition.position;
            pickedObject.transform.SetParent(holdPosition);
        }
    }

    void DropObject()
    {
        if (pickedObject != null)
        {
            pickedRigidbody.isKinematic = false;
            pickedObject.transform.SetParent(null);
            pickedObject = null;
            pickedRigidbody = null;
        }
    }

    void ThrowObject()
    {
        if (pickedObject != null)
        {
            pickedRigidbody.isKinematic = false;
            pickedObject.transform.SetParent(null);
            pickedRigidbody.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
            pickedObject = null;
            pickedRigidbody = null;
        }
    }

    void Paint()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(bullet, hit.point, transform.rotation);

            paintObject = hit.collider.gameObject; 
            PaintScript paint = paintObject.GetComponent<PaintScript>();

            paint.TakeDamage(1);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * maxInteractRange);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxInteractRange))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
    }
}