using System.Text;

namespace HangmanLibrary.Components
{
    public interface IKeywordAssembler
    {
        IHasKeyword HasKeyword { get; }
        StringBuilder Assembler { get; }
        
        string ToString();
        void UpdateAssembler();
        void UpdateAssembler(string input);
    }
}