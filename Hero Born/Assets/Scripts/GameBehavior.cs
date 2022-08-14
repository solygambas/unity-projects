using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;
using CustomExtensions;
// using CustomInt = System.Int64;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public const int MaxItems = 5;
    // public readonly int MaxItems;

    public Text HealthText;
    public Text ItemText;
    public Text ProgressText;

    // public CustomInt PlayerHealth = 100;

    public Stack<string> LootStack = new Stack<string>();
    // Queue<string> activePlayers = new Queue<string>();
    HashSet<string> people = new HashSet<string>() { "Joe", "Joan", "Hank" };
    HashSet<string> activePlayers = new HashSet<string>() { "Harrison", "Alex", "Haley" };
    HashSet<string> inactivePlayers = new HashSet<string>() { "Kelsey", "Basel" };
    HashSet<string> premiumPlayers = new HashSet<string>() { "Haley", "Basel" };

    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

    public PlayerBehavior playerBehavior;

    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
        Initialize();
    }

    public void Initialize()
    {
        _state = "Game Manager initialized...";
        // _state.FancyDebug();
        // Debug.Log(_state);
        debug(_state);
        LogWithDelegate(debug);

        LootStack.Push("Sword of Doom");
        LootStack.Push("HP Boost");
        LootStack.Push("Golden Key");
        LootStack.Push("Pair of Winged Boots");
        LootStack.Push("Mythril Bracer");

        // activePlayers.Enqueue("Harrison");
        // activePlayers.Enqueue("Alex");
        // activePlayers.Enqueue("Haley");

        var itemShop = new Shop<Collectable>();
        itemShop.AddItem(new Potion());
        itemShop.AddItem(new Antidote());
        Debug.Log("There are " + itemShop.inventory.Count + " items for sale.");
        Debug.Log("There are " + itemShop.GetStockCount<Potion>() + " items for sale.");
    }

    public Button WinButton;
    public Button LossButton;

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }

        set {
            _itemsCollected = value;
            // Debug.LogFormat("Items: {0}", _itemsCollected);
            ItemText.text = "Items collected: " + Items;
            if(_itemsCollected >= MaxItems)
            {
                WinButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public void RestartScene()
    {
        // SceneManager.LoadScene(0);
        // Time.timeScale = 1f;
        // Utilities.RestartLevel();
        // Utilities.RestartLevel(0);

        try
        {
            Utilities.RestartLevel(-1);
            debug("Level successfully restarted...");
        }
        catch(System.ArgumentException exception)
        {
            Utilities.RestartLevel(0);
            debug("Reverting to scene 0: " + exception.ToString());
        }
        finally
        {
            debug("Level restart has completed...");
        }
    }

    private int _playerHP = 1;
    public int HP
    {
        get { return _playerHP; }

        set {
            _playerHP = value;
            HealthText.text = "Player Health: " + HP;
            
            if(_playerHP <= 0)
            {
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt.";
            }

            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void PrintLoopReport()
    {
        var currentItem = LootStack.Pop();
        var nextItem = LootStack.Peek();
        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!", LootStack.Count);

        // LootStack.Clear();
        // var itemFound = LootStack.Contains("Golden Key");
        // string[] CopiedLoot = new string[5];
        // LootStack.CopyTo(CopiedLoot, 0);
        // LootStack.ToArray();

        // Queues
        // var firstPlayer = activePlayers.Peek();
        // var firstPlayer = activePlayers.Dequeue();
        // Debug.LogFormat(firstPlayer);

        // HashSets
        // people.Add("Walter");
        // people.Remove("Joe");
        // activePlayers.UnionWith(inactivePlayers);
        activePlayers.IntersectWith(premiumPlayers);
        activePlayers.ExceptWith(premiumPlayers);
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task");
    }

    void OnEnable()
    {
        GameObject player = GameObject.Find("Player");
        playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;
        debug("Jump event subscribed...");
    }

    public void HandlePlayerJump()
    {
        debug("Player has jumped...");
    }

    private void OnDisable()
    {
        playerBehavior.playerJump -= HandlePlayerJump;
        debug("Jump event unsubscribed");
    }
}
