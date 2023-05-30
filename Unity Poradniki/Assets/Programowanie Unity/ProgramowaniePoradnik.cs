using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramowaniePoradnik : MonoBehaviour
{
    [SerializeField] private TestingScript testingScript;
    [SerializeField] private bool boolVariable = true;
    [SerializeField] private int intVariable = 150;
    [SerializeField] private float floatVariable = 1.25f;
    [SerializeField] private string stringVariable = "String Variable: Test";

    private void Start()
    {
        // Debug.Log(stringVariable);

        // TestingIf();
        // TesingLoopsAndArrays();

        int addedNumbers = AddNumbers(5, 10);

        Debug.Log(testingScript.Value);
    }

    private void TestingIf()
    {
        int testVaraiable = 10;
        if (testVaraiable == 10)
        {
            Debug.Log("TestVariable jest równe 10");
        }
        else if (testVaraiable == 20)
        {
            Debug.Log("TestVariable jest równe 20");
        }
        else
        {
            Debug.Log("TestVariable jest ró¿ne ni¿ w warunkach");
        }
    }

    private void TesingLoopsAndArrays()
    {
        int[] intArray = new int[3] { 1, 2, 3 };
        List<string> stringList = new List<string>();
        stringList.Add("One");
        stringList.Add("Two");
        stringList.Add("Three");

        for (int i = 0; i < stringList.Count; ++i)
        {
            Debug.Log(stringList[i]);
        }

        foreach (string element in stringList)
        {
            Debug.Log(element);
        }

        int x = 0;
        while (x < 3)
        {
            x += 2;
        }
    }

    private int AddNumbers(int numberOne, int numberTwo)
    {
        return numberOne + numberTwo;
    }
}