using Assets.Travnik.HeroQuest.Scripts.Map;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameBoard GameBoard;
    public GameMap GameMap = new GameMap();

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
    }

    void InitialSetup()
    {
        GameMap.Initialize();
        GameBoard.DrawMap();
    }
}
