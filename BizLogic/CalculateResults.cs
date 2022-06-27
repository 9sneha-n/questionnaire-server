
namespace questionnaire_server.BizLogic;
public class CalculateResults
{
    public Result CalculateResult(List<FilledQuestionnaire> filledQuestionnaire)
    {
        //Calculate the personality type - this is a sample algo for result calc
        int introvertTraitCounter = 0;
        int extrovertTraitCounter = 0;
        int ambivertTraitCounter = 0;

        foreach (var filledQuestion in filledQuestionnaire)
        {
            if (filledQuestion.selectedOptionId == 1)
            {
                extrovertTraitCounter++;
            }
            else if (filledQuestion.selectedOptionId == 2)
            {
                ambivertTraitCounter++;
            }
            else
            {
                introvertTraitCounter++;
            }
        }

        Result result = new Result();

        if (introvertTraitCounter == extrovertTraitCounter)
        {
            result.title = "Ambivert";
            result.description = "Ambivert details";
            return result;
        }

        var intermediate = (introvertTraitCounter > extrovertTraitCounter) ? "Introvert" : "Extrovert";

        if (intermediate == "Introvert")
        {
            if (ambivertTraitCounter >= introvertTraitCounter)
            {
                result.title = "Ambivert";
                result.description = "Ambivert details";
                return result;
            }
            else
            {
                result.title = "Introvert";
                result.description = "Introvert details ";
                return result;
            }
        }
        else
        {
            if (ambivertTraitCounter >= extrovertTraitCounter)
            {
                result.title = "Ambivert";
                result.description = "Ambivert details";
                return result;
            }
            else
            {
                result.title = "Extrovert";
                result.description = "Extrovert Details";
                return result;
            }
        }
    }
}