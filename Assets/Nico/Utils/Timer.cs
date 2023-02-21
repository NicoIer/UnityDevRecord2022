using System;
using System.Threading;

namespace Nico.ECS.Useful
{
    //ToDo 实现通用Timer
    public class Timer
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private event Action action;

        public void Cancle()
        {
            cancellationTokenSource.Cancel();
        }

        public static Timer StartTimer(float second, Action action)
        {
            var timer = new Timer();
            timer.action = action;
            timer.cancellationTokenSource = new CancellationTokenSource();
            throw new NotImplementedException();
        }
    }
}