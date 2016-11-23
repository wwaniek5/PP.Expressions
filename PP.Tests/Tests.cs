using NUnit.Framework;
using PP.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace PP.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase("A*B+C", "AB*C+")]
        [TestCase("A+B*C", "ABC*+")]
        [TestCase("A*(B+C)", "ABC+*")]
        [TestCase("A-B+C", "AB-C+")]
        [TestCase("A*(B+C*D)+E", "ABCD*+*E+")]
        public void InfixToPostfix(string infix, string postfix)
        {
            var sut = new FixConverter();
            sut.ConvertInfixToPostFix(infix).Should().Be(postfix);
        }

        [TestCase(")(", "Incorrect form")]
        [TestCase("ABC+*D$", "Symbol not allowed")]
        public void InfixToPostfixThrowsExceptionIfIncorrect(string infix, string exceptionMessage)
        {
            var sut = new FixConverter();
            Exception exception = null;
            try
            {
                sut.ConvertInfixToPostFix(infix);
            }
            catch (Exception e)
            {

                exception = e;
            }

            exception.Message.Should().Be(exceptionMessage);
        }

        [TestCase("AB*CD/+", "+*AB/CD")]
        [TestCase("ABC+*D/", "/*A+BCD")]
        [TestCase("ABCD/+*", "*A+B/CD")]
        public void PostfixToPrefix(string postfix, string prefix)
        {
            var sut = new FixConverter();
            sut.ConvertPostfixToPrefix(postfix).Should().Be(prefix);
        }

        [TestCase("A+B@", "Incorrect form")]
        [TestCase("ABC+*D$", "Symbol not allowed")]
        public void PostfixToPrefixThrowsExceptionIfIncorrect(string postfix,string exceptionMessage)
        {
            var sut = new FixConverter();
            Exception exception = null;
            try
            {
                sut.ConvertPostfixToPrefix(postfix);
            }
            catch (Exception e)
            {

                exception = e;
            }

            exception.Message.Should().Be(exceptionMessage);
        }

        [TestCase("+*AB/CD", "((A*B)+(C/D))")]
        [TestCase("/*A+BCD", "((A*(B+C))/D)" )]
        [TestCase("*A+B/CD", "(A*(B+(C/D)))")]
        public void PrefixToInfix(string prefix, string infix)
        {
            var sut = new FixConverter();
            sut.ConvertPrefixToInfix(prefix).Should().Be(infix);
        }

        [TestCase("AB", "Incorrect form")]
        [TestCase("+A", "Incorrect form")]
        [TestCase("*A$", "Symbol not allowed")]
        public void PrefixToInfixThrowsExceptionIfIncorrect(string prefix, string exceptionMessage)
        {
            var sut = new FixConverter();
            Exception exception = null;
            try
            {
                sut.ConvertPrefixToInfix(prefix);
            }
            catch (Exception e)
            {

                exception = e;
            }

            exception.Message.Should().Be(exceptionMessage);
        }
    }
}
