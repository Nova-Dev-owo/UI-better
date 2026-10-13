using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UIElements;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;



public class Inventory : MonoBehaviour
{
    List<string> items = new List<string>();
    List<int> itemsAmmount = new List<int>();
    public TMP_InputField PlayerText;
    public TMP_InputField PlayerAmount;
    public string SetText;
    public int SetAmmount;
    public GameObject text;
    public GameObject contentItem;
    public GameObject contentAmount;



    public void EndTypeAmmount()
    {
        SetAmmount = int.Parse(PlayerAmount.text);
        Debug.Log(SetAmmount);
    }

    public void EndTypeItem()
    {

        SetText = PlayerText.text;
        Debug.Log(SetText);

    }
    public void ButtonPressRemove()
    {
        if (items.Contains(SetText))
        {
            int index = items.FindIndex(text => text == SetText);
            itemsAmmount[index] -= SetAmmount;
            if (itemsAmmount[index] <= 0)
            {
                items.Remove(SetText);
                itemsAmmount.RemoveAt(index);
            }
            UIReset();
        }


    }
    public void ButtonPressAdd()
    {
        if (SetText == null || SetAmmount <= 0)
        {
            return;
        }
        
        else
        {
            if (items.Contains(SetText))
            {
                int index = items.FindIndex(text => text == SetText);
                itemsAmmount[index] += SetAmmount;
                
                if (itemsAmmount[index] <= 0)
                {
                    items.Remove(SetText);
                    itemsAmmount.RemoveAt(index);
  
                }
                
                UIReset();


            }
            else
            {
                items.Add(SetText);
                itemsAmmount.Add(SetAmmount);
                UIReset();


            }
        }
       
    }
    
    private void UIReset()
    {
        foreach (Transform child in contentAmount.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in contentItem.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (int amount in itemsAmmount)
        {
            GameObject ItemTextAmount = Instantiate(text, contentAmount.transform);
            ItemTextAmount.GetComponent<TMP_Text>().text = $"{amount}";
        }
        foreach (string item in items)
        {
            GameObject ItemTextAmount = Instantiate(text, contentItem.transform);
            ItemTextAmount.GetComponent<TMP_Text>().text = item;
        }
        
    }
}
