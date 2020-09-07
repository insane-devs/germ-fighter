using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;

    public GunController theGun;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Update()
    {
        if (pointerDown)
        {
            theGun.isFiring = true;
        } else
        {
            theGun.isFiring = false;
        }
    }

    private void Reset()
    {
        pointerDown = false;
    }
}
