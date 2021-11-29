using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Delore.UI
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        private RectTransform objectRectTransform;//pozycja twojego obiektu
        [SerializeField] Types type; // typ przygotowany na przysz�o�� 
        public void OnDrop(PointerEventData eventData) // metoda u�ywana przy puszaniu myszy
        {
            switch ((int)type) {//sprawdzamy typ
                case 0:
                    if (eventData.pointerDrag != null)//je�eli co� przeci�gamy wykonaj 
                    {
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = objectRectTransform.anchoredPosition;//zmie� pozycje przeci�ganego obiektu na pozycje slotu w UI
                        eventData.pointerDrag.GetComponent<DragAndDrop>().changed = true; // zmie� warto�� w skrypcie obiektu by nie wr�ci� na pozycj� startow�
                    }
                    break;
                case 1:
                    break;
            }
        }
        private void Start()
        {
            objectRectTransform = GetComponent<RectTransform>(); // ustalamy pozycj� dla naszego slotu
        }
    }

    enum Types
    {
        ChestItems,
        Helmet,
        ChestPlate,
        Boots,
        Weapon,
        Ring
    }
}
