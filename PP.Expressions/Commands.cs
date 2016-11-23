using CLAP;

namespace PP.Expressions
{
    internal class Commands
    {
        private ConsoleWriter _consoleWriter;
        private ExpressionsConverter _expressionsConverter;

        public Commands(ConsoleWriter consoleWriter,ExpressionsConverter expressionsConverter)
        {
            _consoleWriter = consoleWriter;
            _expressionsConverter = expressionsConverter;
        }


        [Verb(Aliases = "pre")]
        public void ConvertPrefix([Required] string prefix)
        {
            var infix = _expressionsConverter.ConvertPrefixToInfix(prefix);
            var postfix = _expressionsConverter.ConvertInfixToPostFix(infix);

            _consoleWriter.DisplayResult("infix", infix);
            _consoleWriter.DisplayResult("postfix", postfix);
        }

        [Verb(Aliases = "in")]
        public void ConvertInfix([Required] string infix)
        {
            var postfix = _expressionsConverter.ConvertInfixToPostFix(infix);
            var prefix= _expressionsConverter.ConvertPostfixToPrefix(postfix);

            _consoleWriter.DisplayResult("postfix",postfix);
            _consoleWriter.DisplayResult("prefix", prefix);
        }

        

        [Verb(Aliases = "post")]
        public void ConvertPostfix([Required] string postfix)
        {
            var prefix = _expressionsConverter.ConvertPostfixToPrefix(postfix);
            var infix = _expressionsConverter.ConvertPrefixToInfix(prefix);

            _consoleWriter.DisplayResult("prefix", prefix);
            _consoleWriter.DisplayResult("infix", infix);
        }

    }
}