using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
public class CustomController : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    public float value;
    private Image _container, _joystick;
    private Vector2 _position;

    private ControllerType _type;

    // Start is called before the first frame update
    void Start()
    {
        _container = GetComponent<Image>();
        _joystick =  transform.GetChild(0).GetComponent<Image>();

        if (_container.rectTransform.sizeDelta.x > _container.rectTransform.sizeDelta.y)
            _type = ControllerType.Horizontal;
        else
            _type = ControllerType.Vertical;

    }



    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        value = 0;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
               (_container.rectTransform,
               eventData.position,
               eventData.pressEventCamera,
               out position);

        position.x = (position.x / _container.rectTransform.sizeDelta.x);
        position.y = (position.y / _container.rectTransform.sizeDelta.y);

        if (_type == ControllerType.Horizontal)
        {
            position.x = 2 * (position.x + 0.5f);
            value = position.x;
        }
        else
        {
            position.y = 2 * (position.y - 0.5f);
            value = position.y;
        }

        _joystick.rectTransform.anchoredPosition = new Vector2(position.x * _container.rectTransform.sizeDelta.x / 3,
                                                               position.y * _container.rectTransform.sizeDelta.y / 3);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        value = 0;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
