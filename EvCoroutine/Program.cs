using System;
using System.Collections;

namespace EvCoroutine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoroutineManager.StartCoroutine(Cor1());
            CoroutineManager.StartCoroutine(Cor2());
            CoroutineManager.StartCoroutine(Cor3());

            CoroutineManager.StartCoroutine(Cor4());

            var lastUpdate = DateTime.Now.Ticks;

            while (true)
            {
                if (IsKeyEscapePress())
                    return;

                var currentUpdate = DateTime.Now.Ticks;
                var deltaTime = (float)TimeSpan.FromTicks(currentUpdate - lastUpdate).TotalMilliseconds;

                CoroutineManager.Update();

                lastUpdate = currentUpdate;
            }
        }
        static bool IsKeyEscapePress()
        {
            return (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape);
        }

        
        static IEnumerator Cor1()
        {
            Console.WriteLine("Hello Cor1-in " + DateTime.Now);
            yield return new WaitForSeconds(7f);
            Console.WriteLine("Hello Cor1-out " + DateTime.Now);
            yield break;
        }

        static IEnumerator Cor2()
        {
            Console.WriteLine("Hello Cor2-in " + DateTime.Now);
            yield return new WaitForSeconds(3f);
            Console.WriteLine("Hello Cor2-out " + DateTime.Now);
            yield break;
        }

        static IEnumerator Cor3()
        {
            Console.WriteLine("Hello Cor3-in " + DateTime.Now);
            yield return new WaitForSeconds(5f);
            Console.WriteLine("Hello Cor3-out " + DateTime.Now);
            yield break;
        }


        static IEnumerator Cor4()
        {
            Console.WriteLine("Hello Cor4-in " + DateTime.Now);
            yield return CoroutineManager.StartCoroutine(Cor5(6f));
            Console.WriteLine("Hello Cor4-out " + DateTime.Now);
        }

        static IEnumerator Cor5(float wait)
        {
            Console.WriteLine("Hello Cor5-in  " + DateTime.Now);
            yield return new WaitForSeconds(wait);
            Console.WriteLine("Hello Cor5-out " + DateTime.Now);
        }
    }
}
