using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicArray<T> where T : struct
{
    T[] array;
    public int numberOfItems;

    public DynamicArray(int size)
    {
        array = new T[size];
        numberOfItems = 0;
    }
    
    public ref T this[int i] => ref array[i];

    public void Add(T added)
    {
        if (array.Length <= numberOfItems)
        {
            Array.Resize(ref array,array.Length<<1);
        }
        
        array[numberOfItems++] = added;
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < numberOfItems-1; i++)
        {
            array[i] = array[i + 1];
        }
        numberOfItems--;
    }

    public void Sort(IComparer<T> comparer)
    {
        
    }


    public void ShowItems()
    {
        for (int i = 0; i < numberOfItems; i++)
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
