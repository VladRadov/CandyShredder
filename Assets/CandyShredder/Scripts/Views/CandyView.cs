using UnityEngine;
using UnityEngine.Events;
using UnityFigmaBridge.Runtime.UI;

public class CandyView : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] private FigmaImage _image;

    public UnityEvent BrokeCandyEventHandler = new UnityEvent();

    public void SetImage(Sprite spriteImage) => _image.sprite = spriteImage;

    public void SetActive(bool value) => _transform.gameObject.SetActive(value);

    private void Start()
    {
        _transform = transform;
        BrokeCandyEventHandler.AddListener(() => { SetActive(false); });
    }

    private void OnValidate()
    {
        if (_image == null)
        {
            var transformChild = transform.GetChild(0);
            if (transformChild != null)
                _image = transformChild.GetComponent<FigmaImage>();
        }

        var boxCollider = transform.GetComponent<BoxCollider2D>();
        if (boxCollider == null)
            transform.gameObject.AddComponent<BoxCollider2D>();

        if (boxCollider != null)
            boxCollider.size = new Vector2(24, 24);
    }

    private void OnDestroy()
    {
        BrokeCandyEventHandler.RemoveAllListeners();
    }
}
