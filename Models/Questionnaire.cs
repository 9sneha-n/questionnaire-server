namespace questionnaire_server.Models;

public class Questionnaire {
    public int id {get; set;}
    public string? question {get; set;}
    public List<Option>? options {get; set;}
}


public class Option {
   public int id {get; set;}
   public string? text {get; set;} 
}