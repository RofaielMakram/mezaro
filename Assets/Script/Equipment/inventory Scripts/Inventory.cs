﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    //do not understand
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int Space = 20;
    public bool Add(Item item) 
    {
        if (!item.isDefaultItem) 
        {
            if (items.Count >= Space) 
            {
                Debug.Log("Not enough room");
                return false;
            }

            items.Add(item);
            //do not understand
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }


        return true;
    }

    public void Remove(Item item) 
    {
        items.Remove(item);
        //do not understand
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}