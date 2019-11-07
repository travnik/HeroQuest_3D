using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class PlayerCharacter : MovingObject
    {
        private Outline _outline;

        void Start()
        {
            _outline = GetComponent<Outline>();
            GameManager.Instance.AddPlayerToList(this);
        }

        public void Select()
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }

        public void UnSelect()
        {
            _outline.OutlineMode = Outline.Mode.Disable;
        }
    }
}