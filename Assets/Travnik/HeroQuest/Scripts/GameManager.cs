using UnityEngine;

namespace Travnik.HeroQuest
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameBoard GameBoard;

        public GameObject PlayerPrefab;
        private GameObject _player1;
        private GameObject _player2;

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
            _player1 = AddPiece(PlayerPrefab, 2, 2);
            _player2 = AddPiece(PlayerPrefab, 1, 5);
        }

        public GameObject AddPiece(GameObject prefab, int col, int row)
        {
            return GameBoard.AddPiece(prefab, col, row);
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
            return _player1;
        }
    }
}