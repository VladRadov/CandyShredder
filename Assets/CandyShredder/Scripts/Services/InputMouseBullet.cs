using UnityEngine;
using UnityEngine.Events;

public class InputMouseBullet : BaseInputManager<Vector2>
{
    private Transform _transform;

    [HideInInspector]
    public UnityEvent OnUpdateEventHandler = new UnityEvent();

    public void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pointClick = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)_transform.position;
            InputEventHandler?.Invoke(pointClick);
        }
    }

    public void OnMouseFromPlatform(bool isMouseOnPlatform)
    {
        if (isMouseOnPlatform)
            OnUpdateEventHandler.RemoveListener(UpdateInput);
        else
            OnUpdateEventHandler.AddListener(UpdateInput);
    }

    private void Start()
    {
        _transform = transform;
        OnUpdateEventHandler.AddListener(UpdateInput);
    }

    private void Update()
    {
        OnUpdateEventHandler?.Invoke();
    }

    private void OnDestroy()
    {
        InputEventHandler.RemoveAllListeners();
        OnUpdateEventHandler.RemoveAllListeners();
    }
}
