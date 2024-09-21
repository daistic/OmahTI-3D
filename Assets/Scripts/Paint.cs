using UnityEngine;
using UnityEngine.Rendering;

public class Paint : MonoBehaviour
{
    public int damage = 1;
    [SerializeField] Camera cam;
    [SerializeField] GameObject bullet;
    GameObject paintObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Paints();
        }
    }
    void Paints()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(bullet, hit.point, transform.rotation);

            paintObject = hit.collider.gameObject;

            if (paintObject != null && hit.collider.CompareTag("Paintable"))
            {
                PaintScript paint = paintObject.GetComponent<PaintScript>();
                paint.TakeDamage(damage);
            }
        }

    }
}
