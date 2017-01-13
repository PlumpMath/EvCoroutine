# EvCoroutine
This is a Coroutine implementation for C#

Coroutine makes writing asynchronous code in C# as easy and natural as writing synchronous code
and allows you to perform asynchronous operations in a single method.
There is one main loop and all those functions that you write are being called by the same main thread in order.

Usage:

    public IEnumerator FooRoutine() 
    {
        // Do something
        yield return new WaitForSeconds(5);
        // Do something else
        // Wait for another co-routine to finish
        yield return CoroutineManager.StartCoroutine(OtherRoutine());
        // Finalize
        yield break;
    }

    public void Update() 
    {
        // Start the co-routine
        CoroutineManager.StartCoroutine(FooRoutine());
    }

    public void Update() 
    {
        // You control the update-rate
        CoroutineManager.Update();
    }
