using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GameStates
{
public class StatesMethod
{
        [Test]
        public void TrueState_States_Count_Is_Zero()
        {
            //Arrange.
            var trueState = new TrueStateStab(null);

            //Assert.
            Assert.IsTrue(trueState.States().Count() == 0);
        }

            [Test]
            public void StateMashine_States_Count_Is_Number()
            {
                //Arrange.
                var stateMashine = new StateMashineStab(null);
        
                //Assert.
                Assert.IsTrue(stateMashine.States().Count() == StateMashineStab.NumberOfStates);
            }

        private class StateMashineStab : GameStates.GameStateMachine
        {
            public const int NumberOfStates = 2;

            public StateMashineStab(IStateParent switcher) : base(switcher)
            {
                _states = new GameState[NumberOfStates]
                {
                    new TrueStateStab(this),
                    new TrueStateStab(this)
                };
            }

            protected override void OnStarted()
            {
                throw new System.NotImplementedException();
            }

            protected override void OnStoped()
            {
                throw new System.NotImplementedException();
            }
        }

        private class TrueStateStab : TrueGameState<AvaliableActions.DefaultActionList>
        {
            public TrueStateStab(IStateParent switcher) : base(switcher)
            {
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                throw new System.NotImplementedException();
            }

            protected override void OnStarted()
            {
                throw new System.NotImplementedException();
            }

            protected override void OnStoped()
            {
                throw new System.NotImplementedException();
            }
        }

}
}