using UnityEngine;

public class InputMouseBullet : BaseInputManager<Vector2>
{
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pointClick = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)_transform.position;
            InputEventHandler?.Invoke(pointClick);
        }
    }

    private void OnDestroy()
    {
        InputEventHandler.RemoveAllListeners();
    }
}
