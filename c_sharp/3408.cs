public class TaskManager
{
    private readonly Dictionary<int, int> taskPriorityMap = new();
    private readonly Dictionary<int, int> taskUserMap = new();
    private readonly PriorityQueue<(int taskId, int priority), (int negPriority, int negTaskId)> pq = new();

    public TaskManager(IList<IList<int>> tasks)
    {
        foreach (var task in tasks)
        {
            int userId = task[0];
            int taskId = task[1];
            int priority = task[2];
            taskPriorityMap[taskId] = priority;
            taskUserMap[taskId] = userId;
            pq.Enqueue((taskId, priority), (-priority, -taskId));
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        taskPriorityMap[taskId] = priority;
        taskUserMap[taskId] = userId;
        pq.Enqueue((taskId, priority), (-priority, -taskId));
    }

    public void Edit(int taskId, int newPriority)
    {
        taskPriorityMap[taskId] = newPriority;
        pq.Enqueue((taskId, newPriority), (-newPriority, -taskId));
    }

    public void Rmv(int taskId)
    {
        taskPriorityMap.Remove(taskId);
        taskUserMap.Remove(taskId);
    }

    public int ExecTop()
    {
        while (pq.Count > 0)
        {
            var (taskId, priority) = pq.Dequeue();

            if (!taskPriorityMap.ContainsKey(taskId))
                continue;

            int correctPriority = taskPriorityMap[taskId];
            if (priority != correctPriority)
                continue;

            int userId = taskUserMap[taskId];
            Rmv(taskId);
            return userId;
        }
        return -1;
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */