using UnityEngine;

public class RotationCanvas : MonoBehaviour
{
    [SerializeField] private  GameObject _parent;

    private RectTransform  _rectTransform; 
    private Quaternion _rotation = Quaternion.identity;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(_rectTransform.rotation != _parent.transform.localRotation)
        {
            transform.rotation = _rotation;
        }
        else
        {
            transform.rotation = _rotation;
        }
    }
}
