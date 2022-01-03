using System;

public interface IStatable
{
    void StartState(StateType state);
    void EndState(StateType state);
}

public enum StateType
{
    Higlighted,
    Selected
}
