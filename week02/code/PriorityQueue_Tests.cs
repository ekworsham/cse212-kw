using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Items are added to the back in the insertion order
    // Expected Result: Adds First, Second, Third and checks the queue order 
    // Defect(s) Found: adds second not first as expected. I updated Enqueue to create a new PriorityItem and use _queue.Add to ensure each new item is added to the back of the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual(
            "[First (Pri:1), Second (Pri:3), Third (Pri:2)]",
            priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue removes the highest priority
    // Expected Result: Adds priorities 1, 10, 5 and expects "High" (priority 10)
    // Defect(s) Found: Dequeue loop did not check the last item because of the - 1 so I changed the condition removing - 1 so the last item is checked
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

      [TestMethod]
    // Scenario: Equal prriorities and handled FIFO
    // Expected Result: Frist and Second both have priority 10, expects "First"
    // Defect(s) Found: Error; Returns "Second". Changed operator >= (which caused the later item to replacd the earlier item) to > so the first item with highest priority is returned when they are equal 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

      [TestMethod]
    // Scenario: Attempt to remove an item from an empty queue
    // Expected Result: throws the message "The queue is empty"
    // Defect(s) Found: Did not throw message, added the empty queue check that throws an Invalid Operation Exception with the expected message.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    // Add more test cases as needed below.






    
}