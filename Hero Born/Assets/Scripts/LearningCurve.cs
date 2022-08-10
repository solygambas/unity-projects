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

    // control flow
    // public bool hasDungeonKey = true;
    // public int CurrentGold = 32;
    // public bool PureOfHeart = true;
    // public bool HasSecretIncantation = false;
    // public string RareItem = "Relic Stone";
    // string CharacterAction = "Attack";
    int DiceRoll = 7;

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

        // int CharacterLevel = 32;
        // int NextSkillLevel = GenerateCharacter("Spike", CharacterLevel);

        // Debug.Log(NextSkillLevel);
        // Debug.Log(GenerateCharacter("Spike", CharacterLevel));

        // PrintParameter(CharacterLevel);

        // if-else
        // if(hasDungeonKey)
        // {
        //     Debug.Log("You possess the sacred key - enter.");
        // }
        // else
        // {
        //     Debug.Log("You have not proved yourself yet.");
        // }
        // Thievery();
        // OpenTreasureChamber();

        // switch
        // PrintCharacterAction();
        RollDice();
    }

    // method
    // void ComputeAge()
    // {
    //     Debug.Log(CurrentAge + AddedAge);
    // }

    // public int GenerateCharacter(string name, int level)
    // {
    //     // Debug.LogFormat("Character : {0} - Level: {1}", name, level);
    //     return level += 5;
    // }

    // public void PrintParameter(int number)
    // {
    //     Debug.Log(number);
    // }

    // public void Thievery()
    // {
    //     if(CurrentGold > 50)
    //     {
    //         Debug.Log("You're rolling in it!");
    //     } else if (CurrentGold < 15)
    //     {
    //         Debug.Log("Not much there to steal...");
    //     } else
    //     {
    //         Debug.Log("Looks like your purse is in the sweet spot.");
    //     }
    // }

    // public void OpenTreasureChamber()
    // {
    //     if(PureOfHeart && RareItem == "Relic Stone")
    //     {
    //         if(!HasSecretIncantation)
    //         {
    //             Debug.Log("You have the spirit, but not the knowledge.");
    //         }
    //         else
    //         {
    //             Debug.Log("The treasure is yours, worthy hero!");
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log("Come back when you have what it takes.");
    //     }
    // }

    // public void PrintCharacterAction()
    // {
    //     switch(CharacterAction)
    //     {
    //         case "Heal":
    //             Debug.Log("Potion sent.");
    //             break;
    //         case "Attack":
    //             Debug.Log("To arms!");
    //             break;
    //         default:
    //             Debug.Log("Shields up.");
    //             break;
    //     }
    // } 

    public void RollDice()
    {
        switch(DiceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediocre damage, not bad.");
                break;
            case 20:
                Debug.Log("Critical hit, the creature goes down!");
                break;
            default:
                Debug.Log("You completely missed and fell on your face.");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
