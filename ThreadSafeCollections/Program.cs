using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        #region ConcurrentBag
        ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

        Parallel.For(1, 6, i =>
        {
            concurrentBag.Add(i);
            Console.WriteLine($" added: {i}");
        });

        remove elements
        Parallel.For(1, 8, i =>
        {
            TryTake
            if (concurrentBag.TryTake(out var result))
            {
                Console.WriteLine($" removed: {result}");
            }
            else
            {
                Console.WriteLine($" the bag is empty.");
            }
        });

        Other methods of ConcurrentBag
        Console.WriteLine($"IsEmpty: {concurrentBag.IsEmpty}"); // True
        Console.WriteLine($"Count: {concurrentBag.Count}"); // 0
        #endregion

        #region ConcurrentQueue()
        ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

        concurrentQueue.Enqueue(1);
        concurrentQueue.Enqueue(2);
        concurrentQueue.Enqueue(3);
        concurrentQueue.Enqueue(4);

        for (int i = 0; i < 10; i++)
        {
            concurrentQueue.Enqueue(i);

            if (concurrentQueue.TryDequeue(out var result))
            {
                Console.WriteLine($"dequeued: {result}");
            }
            else
            {
                Console.WriteLine($" attempted to dequeue, but the queue is empty.");
            }

            Console.WriteLine(i);
        }

        int item;
        concurrentQueue.TryPeek(out item);
        Console.WriteLine(item);
        #endregion

        #region ConcurrentStack()

        Create a ConcurrentStack
        ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

        Push elements
        concurrentStack.Push(1);
        concurrentStack.Push(2);
        concurrentStack.Push(3);

        Display the initial state of the stack
        Console.WriteLine("Initial Stack:");
        PrintStack(concurrentStack);

        TryPeek
        if (concurrentStack.TryPeek(out var peekedElement))
        {
            Console.WriteLine($"Peeked at the top element: {peekedElement}");
        }
        else
        {
            Console.WriteLine("Stack is empty.");
        }

        TryPop
        bool popped = concurrentStack.TryPop(out var poppedElement);
        Console.WriteLine($"TryPop result: {popped} - Popped element: {poppedElement}");
        Console.WriteLine("After TryPop:");
        PrintStack(concurrentStack);

        Push multiple elements
        concurrentStack.Push(4);
        concurrentStack.Push(5);
        concurrentStack.Push(6);

        Console.WriteLine("After additional Push operations:");
        PrintStack(concurrentStack);

        ToArray
        int[] array = concurrentStack.ToArray();
        Console.WriteLine("Stack elements converted to array:");
        foreach (var element in array)
        {
            Console.WriteLine(element);
        }

        Clear
        concurrentStack.Clear();
        Console.WriteLine("After Clear:");
        PrintStack(concurrentStack);
    }

    static void PrintStack(ConcurrentStack<int> stack)
    {
        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine();
    }

    #endregion

        #region ConcurrentDictionary
    Create a concurrent dictionary
    ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();

    Add elements to the dictionary
   concurrentDictionary.TryAdd(1, "Value1");
    concurrentDictionary.TryAdd(2, "Value2");
            concurrentDictionary.TryAdd(3, "Value3");

             Display the initial state of the dictionary
            Console.WriteLine("Initial Dictionary:");
    PrintDictionary(concurrentDictionary);

    TryGetValue
            if (concurrentDictionary.TryGetValue(2, out var value))
            {
                Console.WriteLine($"Value associated with key 2: {value}");
            }
            else
{
    Console.WriteLine("Key 2 not found in the dictionary.");
}

AddOrUpdate
concurrentDictionary.AddOrUpdate(2, "UpdatedValue2", (key, oldValue) => "UpdatedValue2");
Console.WriteLine("After AddOrUpdate:");
PrintDictionary(concurrentDictionary);

GetOrAdd
var newValue = concurrentDictionary.GetOrAdd(4, "Value4");
Console.WriteLine($"GetOrAdd result for key 4: {newValue}");
Console.WriteLine("After GetOrAdd:");
PrintDictionary(concurrentDictionary);

Remove
bool removed = concurrentDictionary.TryRemove(2, out var removedValue);
Console.WriteLine($"Removed key 2: {removed} - Removed value: {removedValue}");
Console.WriteLine("After TryRemove:");
PrintDictionary(concurrentDictionary);
    }

    #endregion
static void PrintDictionary(ConcurrentDictionary<int, string> dictionary)
{
    foreach (var kvp in dictionary)
    {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
    }
    Console.WriteLine();
}

}
