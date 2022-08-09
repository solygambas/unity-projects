using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    // private int CurrentAge = 30;
    // // CurrentAge = 30;
    // public int AddedAge = 1;
    
    // public float Pi = 3.14f;
    // public string FirstName = "Harrison";
    // public bool IsAuthor = true;

    // conversions
    // int MyInteger = 3;
    // float MyFloat = MyInteger;
    // int ExplicitConversion = (int)3.14;

    // inferred declaration
    // var CurrentAge = 32;

    // Start is called before the first frame update
    void Start()
    {
        // variables
        // Debug.Log(30 + 1);
        // Debug.Log(currentAge + 1);

        // methods
        // ComputeAge();
        // Debug.Log($"A string can have variables like {FirstName} inserted directly!");

        // debug
        // Debug.Log("Text goes here");
        // Debug.LogFormat("Text goes here, add {0} and {1} as variable placeholders", CurrentAge, FirstName);

        int CharacterLevel = 32;
        // int NextSkillLevel = GenerateCharacter("Spike", CharacterLevel);

        // Debug.Log(NextSkillLevel);
        // Debug.Log(GenerateCharacter("Spike", CharacterLevel));

        PrintParameter(CharacterLevel);
    }

    // method
    // void ComputeAge()
    // {
    //     Debug.Log(CurrentAge + AddedAge);
    // }

    public int GenerateCharacter(string name, int level)
    {
        // Debug.LogFormat("Character : {0} - Level: {1}", name, level);
        return level += 5;
    }

    public void PrintParameter(int number)
    {
        Debug.Log(number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
