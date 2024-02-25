using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void TestDelegate();
    private TestDelegate testDelegateFunction;

    private void Start()
    {
        testDelegateFunction = MyTestDelegateFunction;
        testDelegateFunction();
    }

    private void MyTestDelegateFunction()
    {
        Debug.Log("My Degelate function");
    }

}
