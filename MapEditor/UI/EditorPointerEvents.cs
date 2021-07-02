﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MapEditor
{
    class EditorPointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        public Action<GameObject> pointerEnter;
        public Action<GameObject> pointerExit;
        public Action<GameObject> pointerDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            this.pointerDown?.Invoke(this.gameObject);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            this.pointerEnter?.Invoke(this.gameObject);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.pointerExit?.Invoke(this.gameObject);
        }
    }
}
