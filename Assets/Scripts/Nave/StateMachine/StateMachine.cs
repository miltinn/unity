using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        IDLE,
        RUNNING,
        DEAD
    }

    //chave
    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currentState;
    public Player player;
    public float timeToStartGame = 1f;

    private void Awake()
    {
        dictionaryState= new Dictionary<States, StateBase>();
        dictionaryState.Add(States.IDLE, new StateBase());
        dictionaryState.Add(States.RUNNING, new StateRunning());
        dictionaryState.Add(States.DEAD, new StateDead());

        SwitchState(States.IDLE);

        Invoke(nameof(StartGame), timeToStartGame);
    }

    private void StartGame()
    {
        SwitchState(States.RUNNING);
    }

    private void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter(player);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchState(States.DEAD);
        }
    }
}
