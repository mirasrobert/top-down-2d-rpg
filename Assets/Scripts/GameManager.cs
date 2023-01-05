using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {   
            // Destroy duplicate gamemanager
            return;
        }

        // Check that we have only 1 game manager
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        // Persist Gamemanager if change scene
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public PlayerMovement player;

    // Weapoh

    public FloatingTextManager floatingTextManager;

    public int money;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    /* Save State
     * int preferedSkin 
     * int money
     * int experience
     * int weaponLevel
     */

    char separation = '|';

    public void SaveState()
    {
        string save = "";

        // [0] Skin
        save += "0" + separation;
        // [1] Money
        save += money.ToString() + separation;
        // [2] Exp
        save += experience.ToString() + separation;
        // [3] Weapon lvl
        save += "0";

        PlayerPrefs.SetString("SaveState", save); 
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        // Check if player has save data
        if (!PlayerPrefs.HasKey("SaveState")) return;

        string[] data = PlayerPrefs.GetString("SaveState").Split(separation);

        // Change player skin

        // Load money
        money = int.Parse(data[1]);

        // Load Exp
        experience = int.Parse(data[2]);

        // Load Weapon

        Debug.Log("load state");
    }
}
