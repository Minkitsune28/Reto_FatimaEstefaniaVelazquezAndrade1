using System.Collections.Generic;
using System.Text.RegularExpressions;

// Clase estática encargada de validar la información
// y devolver la versión junto con el resultado
public static class VersionValidator
{
    // Método principal que recibe la cadena de entrada
    public static string Procesar(string input)
    {
        // Validación inicial:
        // Si la entrada está vacía, nula o solo contiene espacios,
        // no se puede procesar y se devuelve error inmediato.
        if (string.IsNullOrWhiteSpace(input))
            return "Version 3.3|Error";

        // Intenta convertir la cadena en clave:valor
        // Si falla el parseo (formato incorrecto, claves duplicadas, etc.),
        // se devuelve Error con la versión correspondiente
        if (!TryParseInput(input, out Dictionary<string, string> datos))
            return $"{DeterminarVersion(datos)}|Error";

        // Validar el contenido
        bool esValido = ValidarDatos(datos);

        // Determinar la versión según los campos presentes
        string version = DeterminarVersion(datos);

        // Construir el resultado final
        return $"Version {version}|{(esValido ? "Success" : "Error")}";
    }

    // ===============================
    // MÉTODO DE PARSEO
    // ===============================
    // Convierte la cadena en un diccionario clave:valor
    static bool TryParseInput(string input, out Dictionary<string, string> datos)
    {
        // Inicializa el diccionario
        datos = new Dictionary<string, string>();

        // Separa la cadena usando '|'
        string[] pares = input.Split('|');

        // Recorre cada par clave:valor
        foreach (string par in pares)
        {
            // Cada par debe contener ':'
            if (!par.Contains(":")) return false;

            string[] partes = par.Split(':');

            // Debe haber exactamente una clave y un valor
            if (partes.Length != 2) return false;

            // Normaliza la clave a minúsculas para evitar problemas
            string key = partes[0].Trim().ToLower();
            string value = partes[1].Trim();

            // Ni la clave ni el valor pueden estar vacíos
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                return false;

            // No se permiten claves duplicadas
            if (datos.ContainsKey(key))
                return false;

            // Agrega el par al diccionario
            datos.Add(key, value);
        }

        // Si todo fue correcto, retorna true
        return true;
    }

    // ===============================
    // VALIDACIÓN GENERAL
    // ===============================
    // Llama a todas las validaciones individuales
    static bool ValidarDatos(Dictionary<string, string> datos)
    {
        return ValidarNombre(datos) &&
               ValidarEdad(datos) &&
               ValidarEstado(datos) &&
               ValidarZipcode(datos) &&
               ValidarStatus(datos);
    }

    // ===============================
    // VALIDACIONES INDIVIDUALES
    // ===============================

    // Valida que exista "name" y tenga al menos 5 caracteres
    static bool ValidarNombre(Dictionary<string, string> datos)
        => datos.ContainsKey("name") && datos["name"].Length >= 5;

    // Valida que exista "age", sea numérico y >= 18
    static bool ValidarEdad(Dictionary<string, string> datos)
        => datos.ContainsKey("age") &&
           int.TryParse(datos["age"], out int edad) &&
           edad >= 18;

    // Valida que exista "state" y tenga al menos 5 caracteres
    static bool ValidarEstado(Dictionary<string, string> datos)
        => datos.ContainsKey("state") && datos["state"].Length >= 5;

    // Valida zipcode solo si existe
    // Debe ser exactamente de 5 dígitos
    static bool ValidarZipcode(Dictionary<string, string> datos)
        => !datos.ContainsKey("zipcode") ||
           Regex.IsMatch(datos["zipcode"], @"^\d{5}$");

    // Valida status solo si existe
    // Solo se aceptan los valores "soltero" o "casado"
    static bool ValidarStatus(Dictionary<string, string> datos)
    {
        if (!datos.ContainsKey("status")) return true;

        string status = datos["status"].ToLower();
        return status == "soltero" || status == "casado";
    }

    // ===============================
    // DETERMINAR VERSIÓN
    // ===============================
    // Si existe zipcode o status → versión 4.0
    // Si no existen → versión 3.3
    static string DeterminarVersion(Dictionary<string, string> datos)
    {
        return datos != null &&
              (datos.ContainsKey("zipcode") || datos.ContainsKey("status"))
              ? "4.0"
              : "3.3";
    }
}
