using System.Text;

namespace Application.Common.Authentication;

public interface IPinGenerator
{
    string Generate();
}

public class PinGenerator : IPinGenerator
{
    private static readonly int Length = 6; 

    public string Generate()
    {
        Random random = new();
        StringBuilder builder = new(Length);

        for (int i = 0; i < Length; i++)
        {
            builder.Append(random.Next(0, 10));
        }

        return builder.ToString();
    }
}
