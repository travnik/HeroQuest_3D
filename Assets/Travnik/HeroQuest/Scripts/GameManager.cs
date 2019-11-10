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

        public void SelectPlayer(PlayerCharacter character)
        {
            Debug.Log("SelectPlayer");
            foreach (var item in PlayerCharacteScripts)
            {
                Debug.Log("UnSelect " + item);
                if (item != character)
                {
                    item.UnSelect();
                    PathMover.Instance.ClearMovesNode();
                }
            }
            character.Select();
            PathFinder.Search(GameBoard.GameMap, character.GridPoint.x, character.GridPoint.y, character.MoveStep);
            PathMover.Instance.FillMovesNode();
        }

        public PlayerCharacter GetPlayerAtGrid(Vector2Int gridPoint)
        {
            return PlayerCharacteScripts.FirstOrDefault(o => o.GridPoint == gridPoint);
        }
    }
}