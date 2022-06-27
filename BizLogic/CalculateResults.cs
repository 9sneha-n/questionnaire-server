
namespace questionnaire_server.BizLogic;

public class CalculateResults
{
    private static readonly string INTROVERT_TITLE = "Introvert";
    private static readonly string INTROVERT_DESC = @"Your results indicate that you are more of an introvert. What exactly does this mean?

Introverts tend to enjoy solitude and spending quiet time alone. They expend energy in social situations and prefer not to be the center of attention.

In general, people might describe you as quiet. You probably prefer to spend time alone or with a small group of close friends and family. You may dislike busy social events such as parties and often feel drained after spending a lot of time around people you do not know well.";

    private static readonly string EXTROVERT_TITLE = "Extrovert";
    private static readonly string EXTROVERT_DESC = @"Your results indicate that you are more of an extrovert. What exactly does this mean?

Extroverts tend to be quite outgoing and talkative. They enjoy spending time with other people, and feel energized in social situations. Oftentimes, extroverts like being the focus of attention.

As an extrovert, people probably describe you as friendly and outgoing. You love meeting new people and have no problem making new friends. Spending time with others leaves you feeling energized and inspired.";
    private static readonly string AMBIVERT_TITLE = "Ambivert";
    private static readonly string AMBIVERT_DESC = @"Your results indicate that you have both extrovert and introvert qualities. What exactly does this mean?

Since your results indicate that you are somewhere in the middle of the extrovert/introvert continuum, you tend to have qualities that fit into both ends of the spectrum. You like spending time with others, but you also enjoy having time to yourself. 

You might not mind being the center of attention once in a while, but you probably prefer to stay out of the spotlight on a day-to-day basis.";

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
            result.title = "You are an " + AMBIVERT_TITLE;
            result.description = AMBIVERT_DESC;
            return result;
        }

        var intermediate = (introvertTraitCounter > extrovertTraitCounter) ? "Introvert" : "Extrovert";

        if (intermediate == INTROVERT_TITLE)
        {
            if (ambivertTraitCounter >= introvertTraitCounter)
            {
                result.title = "You are an " + AMBIVERT_TITLE;
                result.description = AMBIVERT_DESC;
                return result;
            }
            else
            {
                result.title = "You are an " + INTROVERT_TITLE;
                result.description = INTROVERT_DESC;
                return result;
            }
        }
        else
        {
            if (ambivertTraitCounter >= extrovertTraitCounter)
            {
                result.title = "You are an " + AMBIVERT_TITLE;
                result.description = AMBIVERT_DESC;
                return result;
            }
            else
            {
                result.title = "You are an " + EXTROVERT_TITLE;
                result.description = EXTROVERT_DESC;
                return result;
            }
        }
    }
}