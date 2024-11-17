using quizApp.Models;
using System.Collections.Generic;
using IRepository;
namespace Repository;

public class TemporalQRepository<T> : ITemporalQuestions<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Update(int index, T data)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index] = data;
        }
        else
        {
            // Handle invalid index, e.g., throw an exception or log a warning
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public List<T> GetList()
    {
       
        return new List<T>(items);

        
    }


    public int Count => items.Count;
}



