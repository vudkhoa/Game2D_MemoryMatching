using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI indexText;

    public static Action<int> onClick;

    private int index;

    public GameObject hideCard;

    public void SetIndexText(int index)
    {
        indexText.text = index.ToString();
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(index);
    }

    public void Swap()
    {
        hideCard.SetActive(!hideCard.activeSelf);
    }
}