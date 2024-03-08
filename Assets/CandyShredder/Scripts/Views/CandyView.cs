using UnityEngine;
using UnityFigmaBridge.Runtime.UI;

public class CandyView : MonoBehaviour
{
    [SerializeField] private FigmaImage _image;

    public void SetImage(Sprite spriteImage) => _image.sprite = spriteImage;

    private void OnValidate()
    {
        if (_image == null)
        {
            var transformChild = transform.GetChild(0);
            if (transformChild != null)
                _image = transformChild.GetComponent<FigmaImage>();
        }
    }
}
