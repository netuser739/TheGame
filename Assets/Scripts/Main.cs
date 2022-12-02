using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class Main : MonoBehaviour
    {

        [SerializeField] private Unit _player;
        [SerializeField] private Bonus[] _winBonuses;
        [SerializeField] private CounterOfBonus _counter;

        private InputController _inputController;

        private ListExecuteObjectController _executeObject;

        IEnumerator interactivEnum;

        // Start is called before the first frame update
        private void Awake()
        {
            _inputController = new InputController(_player);

            _executeObject = new ListExecuteObjectController(_winBonuses);

            _executeObject.Add(_inputController);

            interactivEnum = _executeObject.GetEnumerator();

            _counter.CountOfWinBonus = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (_counter.CountOfWinBonus == _winBonuses.Length) Debug.Log("WIN");

            if (_executeObject.MoveNext())
            {
                IExecute temp = (IExecute)_executeObject.Current;
                temp.Update();
            }
            else
            {
                _executeObject.Reset();
            }


            //for(int i = 0; i < _executeObject.Length; i++)
            //{
            //if (_executeObject.InteractiveObjects[i] == null) continue;

            //_executeObject.InteractiveObjects[i].Update();
            //}

        }
    }
}