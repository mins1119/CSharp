﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterruptingThread
{
    class SideTask
    {
        int count;
        public SideTask(int count)
        {
            this.count = count;
        }
        public void KeepAlive()
        {
            try
            {
                Console.WriteLine("Runnung thread isn't gonna be interrupted");//
                Thread.SpinWait(1000000);       //
                //Thread.Sleep(1000);
                while (count > 0)
                {
                    Console.WriteLine($"{count--} left");
                    Console.WriteLine("Entering into WaitJoinSleep State..");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("\n\n\n\n" +e);
            }
            finally
            {
                Console.WriteLine("Clearing resources...");
            }
        }
    }
    class Program
    {
        private static void printThreadState(System.Threading.ThreadState state)
        {
            Console.WriteLine("스레드 상태 : {0, -16} : {1} \n", state, (int)state);
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            Console.WriteLine("Start() 호출 : {0}", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Starting Thread...");
            t1.Start();
            printThreadState(t1.ThreadState);

            Console.WriteLine("sleep() 호출 : {0}", stopwatch.Elapsed.TotalMilliseconds);
            Thread.Sleep(100);
            printThreadState(t1.ThreadState);

            Console.WriteLine("Interrupting thread...");
            Console.WriteLine("Interrupt() 호출 : {0} ", stopwatch.Elapsed.TotalMilliseconds);
            t1.Interrupt();
            printThreadState(t1.ThreadState);

            Console.WriteLine("Waiting until thresd stops...");
            t1.Join();
            printThreadState(t1.ThreadState);

            Console.WriteLine("Finished");
            Console.WriteLine("끝남: {0} ", stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
