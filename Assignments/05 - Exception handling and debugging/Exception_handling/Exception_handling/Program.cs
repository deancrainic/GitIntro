using System;

namespace Exception_handling 
{
    internal class Program
    {
        static double Calculate(double firstNumber, double secondNumber, char operation)
        {
            double result = 0;

            switch (operation)
            {
                case '+':
                    try
                    {
                        result = Calculator.Add(firstNumber, secondNumber);
                        return result;
                    }
                    catch (ArithmeticException exception)
                    {
                        Log(exception);
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Log(exception);
                        throw;
                    }
                    break;

                case '-':
                    try
                    {
                        result = Calculator.Substract(firstNumber, secondNumber);
                        return result;
                    }
                    catch (ArithmeticException exception)
                    {
                        Log(exception);
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Log(exception);
                        throw;
                    }
                    break;

                case '*':
                    try
                    {
                        result = Calculator.Multiply(firstNumber, secondNumber);
                        return result;
                    }
                    catch (ArithmeticException exception)
                    {
                        Log(exception);
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Log(exception);
                        throw;
                    }
                    break;

                case '/':
                    try
                    {
                        result = Calculator.Divide(firstNumber, secondNumber);
                        return result;
                    }
                    catch (ArithmeticException exception)
                    {
                        Log(exception);
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Log(exception);
                        throw;
                    }
                    break;

                default:
#if DEBUG
                    Console.WriteLine("Debug");
#endif
                    throw new NoOperatorException("No operator introduced");
                    break;
            }
        }

        private static void Log(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Calculate(2, -4, 'u'));
            }
            catch (ArithmeticException exception)
            {
                Console.WriteLine("ArithmeticException");
            }
            catch (NoOperatorException exception)
            {
                Log(exception);
                Console.WriteLine("NoOperatorException");
            }
            catch (Exception exception)
            {
                Log(exception);
                Console.WriteLine("OtherException");
            }
        }
    }
}