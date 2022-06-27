namespace questionnaire_server;

public class Result {
    public string? title {get; set;}
    public string? description {get; set;}

}


public class FilledQuestionnaire {
    public int questionId {get; set;}
    public int selectedOptionId {get; set;}
}