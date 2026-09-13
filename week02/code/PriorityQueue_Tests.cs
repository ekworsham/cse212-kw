using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items to queue with different priority
    // Expected Result: items added to the back in order they were added 
    // Defect(s) Found: 
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
    // Scenario: Add 3 items with different priorities and remove one item
    // Expected Result: Item with highest priority is removed and returned
    // Defect(s) Found: 
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
    // Scenario: Add multiple items with the same highest priority 
    // Expected Result: The first item with highest priority is removed first.
    // Defect(s) Found: 
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
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    // Add more test cases as needed below.






    
}