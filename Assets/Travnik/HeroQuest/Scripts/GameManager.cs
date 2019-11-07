using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameBoard GameBoard;

        //public GameObject PlayerPrefab;
        private List<PlayerCharacter> PlayerCharacteScripts;

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
            PlayerCharacteScripts = new List<PlayerCharacter>();
            GameBoard.Initialize();
            //_player1 = AddPiece(PlayerPrefab, 2, 2);
            //_player2 = AddPiece(PlayerPrefab, 1, 5);
        }

        public void AddPlayerToList(PlayerCharacter script)
        {
            Debug.Log("add PlayerCharacter " + script);
            PlayerCharacteScripts.Add(script);
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

        public PlayerCharacter PieceAtGrid(Vector2Int gridPoint)
        {
            return PlayerCharacteScripts[0];
        }
    }
}