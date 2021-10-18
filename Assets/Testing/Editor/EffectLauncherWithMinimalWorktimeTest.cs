using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EffectLauncherWithMinimalWorktimeTest
{
    private float _worktime = 1f;

    [Test]
    public void WhenLauncherStarted_AndStopedInstantly_ThenItNotStopEffect()
    {
        //Arrange.
        var launcher= new EffectLaunchers.LauncherWithMinimalWorktime(
            default(StateType),
            _worktime);
        bool effectWasStoped = false;
        launcher.Stoping += () => effectWasStoped = true;

        //Act.
        launcher.Start(default(StateType));
        launcher.Stop(default(StateType));

        //Assert.
        Assert.IsFalse(effectWasStoped);
    }

    [UnityTest]
    public IEnumerator WhenLauncherStarted_AndStopedInstantly_ThenItStopetAfterEnoughTime()
    {
        //Arrange.
        var launcher= new EffectLaunchers.LauncherWithMinimalWorktime(
            default(StateType),
            _worktime);
        bool effectWasStoped = false;
        launcher.Stoping += () => effectWasStoped = true;

        //Act.
        launcher.Start(default(StateType));
        launcher.Stop(default(StateType));
        yield return new WaitForSeconds(_worktime + 1f);

        //Assert.
        Assert.IsTrue(effectWasStoped);
    }

  
}
