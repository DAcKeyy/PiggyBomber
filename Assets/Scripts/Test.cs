using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {

        //text.text = _playerInput.currentControlScheme;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //text.text = "OnPointerDown " + eventData.ToString();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //text.text =  "OnPointerUp " + eventData.ToString();
    }
}
