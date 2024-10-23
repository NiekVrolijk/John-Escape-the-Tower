using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler

{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originallocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private Vector3 originalScale;
    private int currentState = 0;
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponent<Canvas>();
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;

    }
    void Update()
    {
        switch (currentState) 
        {
            case 1:
                HandleHoverState();
                break;

            case 2:
                HandleDrageState();
                if (!Input.GetMouseButton(0)) //check if mouse button is released
                {
                    TransitionToState0();
                }
                break;

            case 3:
                HandlePlayState();
                if (!Input.GetMouseButton(0)) //check if mouse button is released
                {
                    TransitionToState0();
                }
                break;
         
        }

       
    }
    private void TransitionToState0()
    {
        currentState = 0;
        rectTransform.localPosition = originalPosition;
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;
        glowEffect.SetActive(false);
        playArrow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == 0)
        {
            originalPosition = rectTransform.localPosition;
            originalRotation = rectTransform.localRotation;
            originalScale = rectTransform.localScale;
            currentState = 1;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentState == 1) 
        {
            TransitionToState0();   
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentState == 1) 
        {
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out originallocalPointerPosition);
            originalPanelLocalPosition = rectTransform.localPosition;
        }
    }

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        rectTransform.localScale = originalScale * selectScale;
    }

    

}
