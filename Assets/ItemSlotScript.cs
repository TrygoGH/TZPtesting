using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlotScript : MonoBehaviour
{
    [SerializeField] private ItemDataSO item;
    [SerializeField] private RectTransform outerSlot;
    [SerializeField] private RectTransform innerSlot;
    [SerializeField] private TMP_Text itemText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int slotWidth;
    [SerializeField] private int slotHeight;
    public void Start()
    {
        InitComponents();
        Init();
    }

    private void Update()
    {
        Debug.Log(item.AttackDmg);  
    }

    private void Init()
    {
        itemImage.sprite = item.sprite != null ? item.sprite : null;
        itemImage.enabled = itemImage.sprite == null ? false : true;
        itemText.text = item.name;
        SetSize(slotWidth, slotHeight);
        
    }

    public void SetItem()
    {
  
    }

    public void SetSize(int width, int height, float innerSlotWidth = 0.9f)
    {
        slotWidth = width;
        slotHeight = height;
        outerSlot.sizeDelta = new Vector2(width, height);
        innerSlot.sizeDelta = new Vector2(width * innerSlotWidth, height * innerSlotWidth);
       
    }

    private void InitComponents()
    {
     
        //
        
    }
}

   



    
