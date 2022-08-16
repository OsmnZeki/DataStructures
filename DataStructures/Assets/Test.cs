using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TestStruct
{
    public int intValue;
    public float floatValue;

    public override string ToString()
    {
        String s = "intValue: " + intValue + "\n floatValue: " + floatValue;
        return s;
    }
}


public class Test : MonoBehaviour
{
    void Start()
    {
        DynamicArray<TestStruct> dynamicArray = new DynamicArray<TestStruct>(4);

        for (int i = 0; i < 9; i++)
        {
            dynamicArray.Add(new TestStruct()
            {
                floatValue = i,
                intValue = i,
            });
        }

        dynamicArray.RemoveAt(1);
        
        dynamicArray.ShowItems();
        Debug.Log("---------------");
        dynamicArray.ShowAll();
    }

    // Update is called once per frame
    void Update()
    {
    }
}