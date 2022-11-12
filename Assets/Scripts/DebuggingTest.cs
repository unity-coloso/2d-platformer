using System;
using UnityEngine;

public class DebuggingTest : MonoBehaviour
{
    int Add(int a, int b)
    {
        return a + b;
    }

    int Divide(int a, int b)
    {
        int result = 0;

        try
        {
            result = a / b;
        }
        catch (DivideByZeroException e)
        {
            Debug.Log(e);
        }
        finally
        {
            Debug.Log("Divide() 함수 호출이 종료되었습니다.");
        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        Calculate();
    }

    void Calculate()
    {
        Log();
    }

    void Log()
    {
        Debug.Log(Add(12, 3));
        Debug.Log(Divide(12, 3));
        Debug.Log(Divide(12, 0));
    }
}
