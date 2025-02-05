using UnityEngine;

public class CameraZoom2D : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 7f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            return;
        }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Zoom(scroll);
        }
    }

    void Zoom(float scroll)
    {
        float newSize = cam.orthographicSize - scroll * zoomSpeed;
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        cam.orthographicSize = newSize;
    }
}