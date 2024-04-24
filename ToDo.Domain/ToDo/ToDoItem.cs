namespace ToDo.Domain.ToDo;

public class ToDoItem(string title, string description)
{
    public int Id { get; set; }
    public string Title { get; } = title;
    public string Description { get; } = description;
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime? CompletedAt { get; private set; }
    public string? CompletedNote { get; private set; }
    
    public bool IsCompleted { get; private set; } = false;
    public void MarkAsCompleted(string? note)
    {
        IsCompleted = true;
        CompletedAt = DateTime.Now;
        CompletedNote = note;
    }
    
    public void MarkAsCompleted(string? note, DateTime completedAt)
    {
        if (completedAt < CreatedAt)
            throw new ArgumentException("Completed date cannot be before created date.");
        MarkAsCompleted(note);
        CompletedAt = completedAt;
    }
}