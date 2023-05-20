using Microsoft.VisualStudio.TestPlatform.TestHost;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void Main_MenuOptionZero_ExitsProgram()
        {
            // Arrange
            var expectedOutput = "Saindo...";
            var input = "0";

            // Act
            var consoleOutput = ExecuteMainWithInput(input);

            // Assert
            Assert.IsTrue(consoleOutput.Contains(expectedOutput));
        }

        [TestMethod]
        public void Main_InvalidMenuOption_DisplaysErrorMessage()
        {
            // Arrange
            var expectedOutput = "Opção inválida.";
            var input = "99";

            // Act
            var consoleOutput = ExecuteMainWithInput(input);

            // Assert
            Assert.IsTrue(consoleOutput.Contains(expectedOutput));
        }


        private string ExecuteMainWithInput(string input)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                Program.Main(new string[0]);
                return sw.ToString().Trim();
            }
        }
    }
}
