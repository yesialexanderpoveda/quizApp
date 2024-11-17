using System.Collections.Generic;
using quizApp.Models;

namespace IRepository
{

public interface ITemporalQuestions<T>
{
    void Add(T item);                
    void Update(int index, T data);             
    void Remove(T item);            
    List<T> GetList();                       
    int Count { get; }     

}

}
