using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicArray<T> where T : struct
{
    T[] array;
    public int itemNumber;

    public DynamicArray(int size)
    {
        array = new T[size];
        itemNumber = 0;
    }
    
    public ref T this[int i] => ref array[i];

    public void Add(T added)
    {
        if (array.Length <= itemNumber)
        {
            Array.Resize(ref array,array.Length*2);
        }
        
        array[itemNumber++] = added;
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < itemNumber-1; i++)
        {
            array[i] = array[i + 1];
        }
        itemNumber--;
    }


    public void ShowItems()
    {
        for (int i = 0; i < itemNumber; i++)
        {
            Debug.Log(array[i]);
        }
    }
    
    public void ShowAll()
    {
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }
    }
    
}
