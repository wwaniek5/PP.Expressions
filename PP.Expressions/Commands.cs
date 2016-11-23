using CLAP;

namespace PP.Expressions
{
    internal class Commands
    {
        private ConsoleWriter _consoleWriter;
        private FixConverter _fixConverter;

        public Commands(ConsoleWriter consoleWriter,FixConverter fixConverter)
        {
            _consoleWriter = consoleWriter;
            _fixConverter = fixConverter;
        }


        [Verb(Aliases = "pre")]
        public void ConvertPrefix([Required] string prefix)
        {

        }

        [Verb(Aliases = "in")]
        public void ConvertInfix([Required] string infix)
        {
            string postfix = _fixConverter.ConvertInfixToPostFix(infix);

            _consoleWriter.DisplayResult("postfix",postfix);
        }

        

        [Verb(Aliases = "post")]
        public void ConvertPostfix([Required] string postfix)
        {

        }

    }
}