using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private int CurrentAge = 30;
    // CurrentAge = 30;
    public int AddedAge = 1;
    public string FirstName = "Harrison";
    // Start is called before the first frame update
    void Start()
    {
        // variables
        // Debug.Log(30 + 1);
        // Debug.Log(currentAge + 1);

        // methods
        ComputeAge();

        // debug
        Debug.Log("Text goes here");
        Debug.LogFormat("Text goes here, add {0} and {1} as variable placeholders", CurrentAge, FirstName);
    }

    // method
    void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
