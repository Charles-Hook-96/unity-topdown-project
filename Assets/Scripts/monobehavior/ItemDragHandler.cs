using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform originalPosition;
    CanvasGroup canvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //saves original position
        originalPosition = transform.parent;

        //Puts it above the other canvas
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;

        //Makes it semi transparent during drag
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Follows mouse drag position
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Makes it clickable after drop, I think?
        canvasGroup.blocksRaycasts = true;

        //Back to solid object
        canvasGroup.alpha = 1f;

        //Slot where the item drops
        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>();

        if (dropSlot == null)
        {
            GameObject item = eventData.pointerEnter;
            if (item != null)
            {
                dropSlot = item.GetComponentInParent<Slot>();
            }
        }

        Slot originalSlot = originalPosition.GetComponent<Slot>();

        if (dropSlot != null)
        {
            if (dropSlot.currentItem != null)
            {
                //Swaps the items if one is already in the current grid slot
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                originalSlot.currentItem = null;
            }

            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else
        {
            transform.SetParent(originalPosition);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

}
