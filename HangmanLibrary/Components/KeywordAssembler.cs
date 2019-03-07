using System.Text;

namespace HangmanLibrary.Components
{
    public class KeywordAssembler : IKeywordAssembler
    {
        public IHasKeyword HasKeyword { get; }
        public StringBuilder Assembler { get; }

        public KeywordAssembler(IHasKeyword hasKeyword)
        {
            HasKeyword = hasKeyword;
            Assembler = new StringBuilder();
        }

        public void UpdateAssembler()
        {
            for (int i = 0; i < HasKeyword.Keyword.Length; i++)
            {
                if (HasKeyword.Keyword[i] == ' ')
                {
                    Assembler.Append(' ');
                }
                else
                {
                    Assembler.Append('_');
                }
            }
        }

        public void UpdateAssembler(string input)
        {
            for (int j = 0; j < HasKeyword.Keyword.Length; j++)
            {
                if (HasKeyword.Keyword[j] == input[0])
                {
                    Assembler[j] = HasKeyword.Keyword[j];
                }
            }
        }

        public override string ToString() => string.Join(" ", Assembler.ToString().ToCharArray());
    }
}