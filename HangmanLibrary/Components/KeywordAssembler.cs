using System.Text;

namespace HangmanLibrary.Components
{
    public class KeywordAssembler : IKeywordAssembler
    {
        public IVsComputer VsComputer { get; }
        public StringBuilder Assembler { get; }

        public KeywordAssembler(IVsComputer vsComputer)
        {
            VsComputer = vsComputer;
            Assembler = new StringBuilder();
        }

        public void UpdateAssembler()
        {
            for (int i = 0; i < VsComputer.Keyword.Length; i++)
            {
                if (VsComputer.Keyword[i] == ' ')
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
            for (int j = 0; j < VsComputer.Keyword.Length; j++)
            {
                if (VsComputer.Keyword[j] == input[0])
                {
                    Assembler[j] = VsComputer.Keyword[j];
                }
            }
        }

        public override string ToString() => string.Join(" ", Assembler.ToString().ToCharArray());
    }
}