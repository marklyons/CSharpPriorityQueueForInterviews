# CSharpPriorityQueueForInterviews

[Priority Queues are available in .NET 6.0](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2?view=net-6.0). However, some companies that use HackerRank/CoderPad/etc. may not have updated to .NET 6.0 just yet and you will be unable to use Priority Queues for your solutions in that case. I'm not sure what is involved in updating those platforms, but I did encounter this once as an interviewee and strangely enough, I did not have this issue on the same platform but with a different company. 

This is a simple Priority Queue implementation that you can use. Most of this is from [this repository](), but I added support for custom comparers and a peek method. Here is an example of it being used as a max heap to get the K smallest elements in a list:

```
MarksPriorityQueue<int> maxHeap = new MarksPriorityQueue<int>(Comparer<int>.Create((x, y) => y - x));

int[] testNums = new int[] { 8, 2, 3, 4, 9, 6, 7, 10 };
int K = 3;

for (int i = 0; i < K; i++)
{
    maxHeap.Enqueue(testNums[i]);
}

for (int i = K; i < testNums.Length; i++)
{
    if (testNums[i] < maxHeap.Peek())
    {
        maxHeap.Dequeue();
        maxHeap.Enqueue(testNums[i]);
    }
}

List<int> resultSet = new List<int>();
for (int i = 0; i < K; i++)
{
    resultSet.Add(maxHeap.Dequeue());
}

Console.WriteLine(string.Join(", ", resultSet));
```