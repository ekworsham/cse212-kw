public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // *****************************************************************
        // PLAN
        // *****************************************************************
        // First, I need to create an array that has enought spaces for however many muliples I want to create. The length tells me how many spaces I will need.
        // Then I need to use a for loop to go throguht each spot in the array.
        // Next, for each spot, I will need to multiply the number by the current number in the loop to figure out the next multiple. 
        // Then I will put each multiple into the array as I go.
        // Once I have filled the array, I will return it.
        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // *****************************************************************
        // PLAN
        // *****************************************************************
        // First I will create a new int list called rotated to hold the numbers in the their new order 
        // Then I will use data.count anount to find the index where the last amount of numbers begin
        // Next I will use a for loop to go through the list starting at that index and add each number to my list using the add function.
        // Then I will use another for loop to go from the begining of the original list up to the starting index and add those numbers to the new list also using the add function.
        // Last, I will clear the original data list and use AddRange() to copy all the numbers from the rotated list back into data in their new order.

        List<int> rotated = new List<int>();
        for (int i =data.Count - amount; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }
        for (int i = 0; i < data.Count - amount; i++)
        {
            rotated.Add(data[i]);
        }
        data.Clear();
        data.AddRange(rotated);
    }
}



