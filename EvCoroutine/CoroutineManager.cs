using System;
using System.Collections;
using System.Collections.Generic;

namespace EvCoroutine
{
    public class CoroutineManager
    {
        private static List<Coroutine> coroutines = new List<Coroutine>();

        public static Coroutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new Coroutine(routine);

            coroutines.Add(coroutine);

            return coroutine;
        }

        public static void Update()
        {
            for (int i = 0; i < coroutines.Count; i++)
            {
                var coroutine = coroutines[i];

                if (!coroutine.MoveNext())
                {
                    coroutines[i] = coroutines[coroutines.Count - 1];
                    coroutines.RemoveAt(coroutines.Count - 1);
                }
            }
        }
    }

    public class YieldInstruction
    {
        internal IEnumerator routine;

        internal YieldInstruction() { }

        internal bool MoveNext()
        {
            var yieldInstruction = routine.Current as YieldInstruction;

            if (yieldInstruction != null)
            {
                if (yieldInstruction.MoveNext())
                {
                    return true;
                }
                else if (routine.MoveNext())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (routine.MoveNext())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Coroutine : YieldInstruction
    {
        public Coroutine(IEnumerator routine)
        {
            this.routine = routine;
        }
    }

    public class WaitForSeconds : YieldInstruction
    {
        public WaitForSeconds(float seconds)
        {
            var delay = DateTime.Now.AddSeconds(seconds);
            this.routine = Count(delay);
        }

        private IEnumerator Count(DateTime delay)
        {
            while (DateTime.Now <= delay)
                yield return true;
        }
    }
}
