using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void TestDelegate();
    private TestDelegate testDelegateFunction;

    public delegate bool testCardValueDelegate(string value);
    private testCardValueDelegate m_TestCardvalueFunction;

    private string m_debugMessage;

    private void Awake()
    {
        // The temp function can't unsubcribe from the delegate since it does not have reference 
        // so it better to create new fucntion and add it ot the delegate.
        testDelegateFunction = delegate () { Debug.Log("Function TBA"); };
        testDelegateFunction();

        testDelegateFunction = MyTestDelegateFunction;
        testDelegateFunction+=SecondDelegateFunction;
        testDelegateFunction();

        m_TestCardvalueFunction = TestCardValue;
        Debug.Log( m_TestCardvalueFunction("J").ToString());

        // New methods can be added in future or test temporary
        m_TestCardvalueFunction = (string s) => { return s == "K"; };
        Debug.Log( m_TestCardvalueFunction("K").ToString());

    }

    private void MyTestDelegateFunction()
    {
        Debug.Log("My Degelate function");
    }

    private void SecondDelegateFunction()
    {
        Debug.Log("Second Delegate Function");
    }

    private bool TestCardValue(string value) 
    {
        return value == "K";
    }

    /* Notes
     There are simliar built types functionalities in "SYSTEM".
     * Action, which does not return type and similar to delegate funcitonality. 
       It can take parameters
     * Func, Which has return Type and other functionalities from Action.
     
     
     */
}
