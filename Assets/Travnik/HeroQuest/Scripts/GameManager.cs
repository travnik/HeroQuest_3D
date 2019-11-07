using System.Collections.Generic;
using System.Linq;
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
        }

        public void AddPlayerToList(PlayerCharacter script)
        {
            PlayerCharacteScripts.Add(script);
        }

        //public GameObject AddPiece(GameObject prefab, int col, int row)
        //{
        //    return GameBoard.AddPiece(prefab, col, row);
        //}

        public void SelectPlayer(PlayerCharacter character)
        {
            Debug.Log("SelectPlayer");
            foreach (var item in PlayerCharacteScripts)
            {
                Debug.Log("UnSelect " + item);
                if (item != character)
                {
                    item.UnSelect();
                }
            }
            character.Select();
        }

        //public void DeselectPiece(GameObject piece)
        //{
        //    GameBoard.DeselectPiece(piece);
        //}

        //public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
        //{
        //    return true;
        //}

        public PlayerCharacter GetPlayerAtGrid(Vector2Int gridPoint)
        {
            return PlayerCharacteScripts.FirstOrDefault(o => o.GridPoint == gridPoint);
        }
    }
}