using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game
{
    public class BadBonus : Bonus
    {
        [SerializeField] private CounterOfBonus _counter;

        [SerializeField] private Unit _player;

        public override void Awake()
        {
            base.Awake();

            if (!_player)
            {
                Debug.Log("NOT Unit Component!");
            }
        }

        public override void Update()
        {

        }

        protected override void Interaction()
        {
            IsInteractable = false;

            if (gameObject.tag == "SpeedDownBonus") _player.Speed = 2f;
        }
    }
}