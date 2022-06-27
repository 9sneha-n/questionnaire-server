using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using questionnaire_server.BizLogic;

namespace questionnaire_server.Controllers;
[ApiController]
public class ResultController : ControllerBase
{

    private readonly ILogger<ResultController> _logger;

    public ResultController(ILogger<ResultController> logger)
    {
        _logger = logger;
    }

    [HttpPost("result/")]
    public Result Result(List<FilledQuestionnaire> filledQuestionnaire)
    {
        _logger.LogInformation("Calculating Results for Questionnaire");
        CalculateResults cr = new CalculateResults();
        return cr.CalculateResult(filledQuestionnaire);
    }
}
