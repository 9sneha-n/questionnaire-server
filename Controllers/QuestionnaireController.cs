using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace questionnaire_server.Controllers;
[ApiController]
[Route("[controller]")]
public class QuestionnaireController : ControllerBase
{
    //Initialize questions in in-memory 
    private static readonly string questionnaire_json = @"[{
                                                            ""id"": 0,
                                                            ""question"": ""To prepare for a night out..."",
                                                            ""options"": [
                                                                {
                                                                    ""id"": 1,
                                                                    ""text"": ""I buy the latest outfit, tell my friends, then dance the night away.""
                                                                },
                                                                {
                                                                    ""id"": 2,
                                                                    ""text"": ""Call a few of my closest friends to see if they will be there.""
                                                                },
                                                                {
                                                                    ""id"": 3,
                                                                    ""text"": ""Prepare? My friends have to drag me out most nights.""
                                                                }
                                                            ]
                                                            },
                                                            {
                                                            ""id"": 1,
                                                            ""question"": ""Being around people makes me feel..."",
                                                            ""options"": [
                                                                {
                                                                    ""id"": 1,
                                                                    ""text"": ""Like I'm alive!""
                                                                },
                                                                {
                                                                    ""id"": 2,
                                                                    ""text"": ""Inspired. I feed off of others' energy but there are times when I'd rather be alone.""
                                                                },
                                                                {
                                                                    ""id"": 3,
                                                                    ""text"": ""A bit exhausted. Being around others can be draining.""
                                                                }
                                                            ]
                                                            },
                                                            {
                                                            ""id"": 2,
                                                            ""question"": ""When given a choice between working as part of a team or working as a group, I would prefer to..."",
                                                            ""options"": [
                                                                {
                                                                    ""id"": 1,
                                                                    ""text"": ""Work with as many people as possible.""
                                                                },
                                                                {
                                                                    ""id"": 2,
                                                                    ""text"": ""Work as part of a small group.""
                                                                },
                                                                {
                                                                    ""id"": 3,
                                                                    ""text"": ""Work by myself.""
                                                                }
                                                            ]
                                                            }]
                                                            ";

    private static List<Questionnaire>? Questions;

    private readonly ILogger<QuestionnaireController> _logger;

    public QuestionnaireController(ILogger<QuestionnaireController> logger)
    {
        _logger = logger;
        try
        {
            Questions = JsonSerializer.Deserialize<List<Questionnaire>>(questionnaire_json);
        }
        catch (Exception e)
        {
            _logger.LogError("Error occured when deserializing questions : " + e.Message);
        }
    }

    [HttpGet(Name = "GetQuestions")]
    public IEnumerable<Questionnaire> Get()
    {
        _logger.LogInformation("Returning Questions for Questionnaire");
        return Questions!;
    }
}
