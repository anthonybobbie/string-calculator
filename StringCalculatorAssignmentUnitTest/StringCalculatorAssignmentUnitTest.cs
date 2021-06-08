using Moq;
using NUnit.Framework;
using StringCalculatorAssignment.Models;
using System;

namespace StringCalculatorAssignmentUnitTest
{
    public class Tests
    {

        DelimeterService delimeterService;
        StringCalculator calculator;

        [SetUp]
        public void Setup()
        {
            delimeterService = new DelimeterService();
        }

        [Test]
        public void StringCalculator_Add_returns_zero_with_empty_string_input()
        {

            calculator = new StringCalculator(delimeterService);
            int answer = calculator.Add("");
            Assert.AreEqual(answer, 0);

        }
        [Test]
        public void StringCalculator_Add_returns_answer_with_two_integer_string_input()
        {


            calculator = new StringCalculator(delimeterService);
            int answer = calculator.Add("1,2");
            Assert.AreNotEqual(answer, 0);
            Assert.AreEqual(answer, 3);
        }
        [Test]
        public void StringCalculator_Add_returns_answer_with_newline_integer_string_input()
        {


            calculator = new StringCalculator(delimeterService);
            int answer = calculator.Add("1\n2,3");
            Assert.AreNotEqual(answer, 0);
            Assert.AreEqual(answer, 6);
        }
        [Test]
        public void StringCalculator_Add_returns_answer_custom_delimeter_integer_string_input()
        {

            calculator = new StringCalculator(delimeterService);
            int answer = calculator.Add("[***]\n1***2***3");
            Assert.AreNotEqual(answer, 0);
            Assert.AreEqual(answer, 6);

        }
        [Test]
        public void StringCalculator_Add_returns_answer_custom2_delimeter_integer_string_input()
        {

            calculator = new StringCalculator(delimeterService);
            int answer = calculator.Add("[;]\n1;2");
            Assert.AreNotEqual(answer, 0);
            Assert.AreEqual(answer, 3);

        }
        [Test]
        public void StringCalculator_Add_returns_answer_with_multiple_delimeter_input()
        {

            calculator = new StringCalculator(delimeterService);
            int answer = calculator.Add("[*][%]\n1*2%3");
            Assert.AreNotEqual(answer, 0);
            Assert.AreEqual(answer, 6);

        }
        [Test]
        public void StringCalculator_Add_returns_error_with_negative_input_Strings()
        {

            calculator = new StringCalculator(delimeterService);
            
             var ex = Assert.Throws<System.Exception>(() => calculator.Add("-3,5,6"));
             Assert.That(ex.Message, Is.EqualTo("negatives not allowed"));
    
        }

        [Test]
        public void StringCalculator_Add_returns_sum_ignoring_integersGreaterThan1000()
        {
            calculator = new StringCalculator(delimeterService);
            var answer= calculator.Add("2,1001");
            Assert.AreEqual(2, answer);

        }
    }
}