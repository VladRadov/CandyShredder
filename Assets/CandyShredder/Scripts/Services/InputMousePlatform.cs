using UnityEngine;

public class InputMousePlatform : BaseInputManager<float>
{
    private Transform _transform;
    private Vector2 _pointClick;

    private void Start()
    {
        _transform = transform;
    }

    private void OnMouseDown()
    {
        _pointClick = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)_transform.position;
    }

    private void OnMouseDrag()
    {
        var pointClick = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - _pointClick;
        InputEventHandler?.Invoke(pointClick.x);
    }

    private void OnDestroy()
    {
        InputEventHandler.RemoveAllListeners();
    }
}
