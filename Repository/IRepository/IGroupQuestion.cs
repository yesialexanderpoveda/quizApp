using DB;

namespace IRepository
{

public interface IGroupQuestion<T>
{

    // cambiar parametros de entrada
    void AddGroupQuestion(GroupQuestions group, Questions questions);                
    void UpdateGroupQuestion(int Id);             
    void RemoveGroupQuestion(int Id);            
    List<T>  GetGroupQuestion(int Id);                          
    List<T> GetGroupQuestionsByUser();
    
    List<T> GetGroupQuestionPublics();
 
    // questions 

    void AddQuestion ();   
    void UpdateQuestion (int Id);  
    void RemoveQuestion(int Id);
    void GetQuestion(int Id);
    
}

}