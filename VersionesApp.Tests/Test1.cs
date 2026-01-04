using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionesApp.Test
{
    // Indica que esta clase contiene pruebas unitarias
    [TestClass]
    public class VersionValidatorTests
    {
        // =======================
        // PRUEBAS VÁLIDAS
        // Estas pruebas verifican
        // que entradas correctas
        // regresen "Success"
        // =======================

        // Prueba una entrada completa con todos los campos
        // Debe devolver versión 4.0 porque incluye zipcode y status
        [TestMethod]
        public void EntradaCompletaValida_Version40_Success()
        {
            string input = "name:Mariana|age:28|state:Queretaro|zipcode:76000|status:Casado";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 4.0|Success", result);
        }

        // Prueba una entrada sin campos opcionales
        // Debe devolver versión 3.3 porque no incluye zipcode ni status
        [TestMethod]
        public void EntradaSinOpcionales_Version33_Success()
        {
            string input = "name:Ricardo|age:35|state:Jalisco";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 3.3|Success", result);
        }

        // Verifica que el campo status sea válido
        // aunque esté escrito en minúsculas
        [TestMethod]
        public void StatusEnMinusculas_Valido()
        {
            string input = "name:Fernanda|age:22|state:Nayarit|status:soltero";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 4.0|Success", result);
        }

        // Verifica que solo con zipcode presente
        // se asigne correctamente la versión 4.0
        [TestMethod]
        public void SoloZipcodeValido_Version40_Success()
        {
            string input = "name:Alberto|age:40|state:Sonora|zipcode:83000";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 4.0|Success", result);
        }

        // =======================
        // PRUEBAS INVÁLIDAS
        // Estas pruebas verifican
        // que entradas incorrectas
        // regresen "Error"
        // =======================

        // El nombre tiene menos de 5 caracteres
        // Debe fallar la validación
        [TestMethod]
        public void NombreMuyCorto_Error()
        {
            string input = "name:Ana|age:20|state:Jalisco";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 3.3|Error", result);
        }

        // La edad no es un número
        // int.TryParse falla y se marca como error
        [TestMethod]
        public void EdadNoNumerica_Error()
        {
            string input = "name:Roberto|age:abc|state:Jalisco";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 3.3|Error", result);
        }

        // La edad es menor a 18
        // No cumple la regla mínima
        [TestMethod]
        public void EdadMenorA18_Error()
        {
            string input = "name:Lucia|age:17|state:Yucatan";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 3.3|Error", result);
        }

        // El estado tiene menos de 5 caracteres
        // No cumple la validación
        [TestMethod]
        public void EstadoMuyCorto_Error()
        {
            string input = "name:Carlos|age:30|state:DF";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 3.3|Error", result);
        }

        // El zipcode no tiene exactamente 5 dígitos
        // La versión es 4.0 porque existe zipcode
        [TestMethod]
        public void ZipcodeInvalido_Error()
        {
            string input = "name:Monica|age:25|state:Jalisco|zipcode:1234";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 4.0|Error", result);
        }

        // El status tiene un valor no permitido
        // Solo se acepta soltero o casado
        [TestMethod]
        public void StatusInvalido_Error()
        {
            string input = "name:Elisa|age:30|state:Jalisco|status:Divorciado";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 4.0|Error", result);
        }

        // Entrada vacía
        // El método se ejecuta pero retorna error inmediato
        [TestMethod]
        public void EntradaVacia_Error()
        {
            string input = "";
            string result = VersionValidator.Procesar(input);

            Assert.AreEqual("Version 3.3|Error", result);
        }

      
    }
}
