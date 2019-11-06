using Assets.Travnik.HeroQuest.Scripts.Map;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameBoard GameBoard;

    public GameObject PlayerPrefab;
    private GameObject _player;

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
        GameBoard.Initialize();
        AddPiece(PlayerPrefab, 2, 2);
    }

    public void AddPiece(GameObject prefab, int col, int row)
    {
        _player = GameBoard.AddPiece(prefab, col, row);
    }

    public void SelectPiece(GameObject piece)
    {
        GameBoard.SelectPiece(piece);
    }

    public void DeselectPiece(GameObject piece)
    {
        GameBoard.DeselectPiece(piece);
    }

    public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    {
        return true;
    }

    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        return _player;
    }
}
