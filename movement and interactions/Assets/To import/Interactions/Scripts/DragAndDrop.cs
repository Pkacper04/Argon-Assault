using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using InteractionHandler.Frame;

namespace InteractionHandler
{
    public class DragAndDrop : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
    {
        public bool changed = false; // bool do sprawdzania czy obiekt dosta� now� pozycj�
        private Vector2 startingposition; // pozycja statrowa 

        private CanvasGroup canvasGroup; // u�ywany do zmiany przezroczysto�ci podnoszonego obiektu i by nie blokowa� promieni 
        private RectTransform rectTransform; // aktualna pozycja obiektu
        private Canvas canvas; // canvas na kt�rym jest umieszczony obiekt


        public void OnBeginDrag(PointerEventData eventData) // podczas gdy zlapiemy obiekt
        {
            startingposition = rectTransform.anchoredPosition;// ustawiamy pozycje startow�
            canvasGroup.alpha = .6f; // zwi�kszamy przezroczysto�� obiektu 
            canvasGroup.blocksRaycasts = false; // ustawienie by ray z myszki przechodzi� przez obiekt
            changed = false; // ustawiamy �e aktualnie obiekt nie ma �adnego nowego slotu
        }

        public void OnDrag(PointerEventData eventData) // podczas przeci�gania
        {
            rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor; // zmieniamy pozycj� naszego obiektu relatywnie do rozmiaru canvasu
        }

        public void OnEndDrag(PointerEventData eventData) // na koniec przeci�gania gdy puszamy klawisz myszy
        {
            canvasGroup.alpha = 1f; // przezroczysto�� wraca do podstawowej pozycji
            canvasGroup.blocksRaycasts = true; // obiekt teraz blokuje raye z myszy
            if (!changed) // je�eli obiekt nie dosta� nowego slotu
                rectTransform.anchoredPosition = startingposition; // to pozycja obiektu wraca do startowej
        }

        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>(); // ustalamy canvasGroup
            rectTransform = GetComponent<RectTransform>(); // ustalamy RectTransform
            canvas = GetComponentInParent<Canvas>(); // ustalamy Canvas
        }


    }



}
