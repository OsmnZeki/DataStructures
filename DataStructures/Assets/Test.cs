using System;
using System.Collections;
using System.Collections.Generic;
using BinaryTree;
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
    BinaryTree<TestStruct> intBinaryTree = new BinaryTree<TestStruct>();
    
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            intBinaryTree.Add(new TestStruct()
            {
                intValue = i,
                floatValue = 1,
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        intBinaryTree.DebugTree();
    }
}