# Reto 1 FATIS
Implementa un validador de cadenas de texto con formato `clave:valor|clave:valor|...`.  
Su objetivo es analizar la información recibida, validar que cumpla con reglas específicas y devolver un resultado indicando la **versión aplicada** y si la información es **válida o no**.

---

## Formato de Entrada

La función principal recibe un `string` con el siguiente formato:

name:Andrea|age:29|state:Jalisco|zipcode:44100|status:Soltero


- Cada par está separado por `|`
- Cada par tiene la forma `clave:valor`

---

## Formato de Salida

El método devuelve un `string` con el formato:
Version {version}|{resultado}
Por ejemplo: 
Version4.0|Success 
Version 3.3|Error

- **Versión 4.0**
  - Se utiliza cuando existe al menos uno de los siguientes campos:
    - `zipcode`
    - `status`

- **Versión 3.3**
  - Se utiliza cuando ninguno de los campos opcionales está presente.

---

## Estructura del Código

VersionValidator
│
├── Procesar()
├── TryParseInput()
├── ValidarDatos()
│ ├── ValidarNombre()
│ ├── ValidarEdad()
│ ├── ValidarEstado()
│ ├── ValidarZipcode()
│ └── ValidarStatus()
└── DeterminarVersion()


---

## Explicación de Métodos

### Procesar(string input)

Es el método principal del sistema.

Funciones:
1. Valida si la entrada está vacía.
2. Convierte la cadena en un diccionario.
3. Ejecuta las validaciones de los datos.
4. Determina la versión correspondiente.
5. Construye y devuelve el resultado final.

---

### TryParseInput(string input, out Dictionary<string,string> datos)

Convierte la cadena de entrada en un diccionario `clave → valor`.

Valida:
- Formato correcto `clave:valor`
- Claves y valores no vacíos
- No existencia de claves duplicadas

---

### ValidarDatos(Dictionary<string,string> datos)

Ejecuta todas las validaciones individuales de manera conjunta.  
Si alguna falla, el resultado general es inválido.

---

## Validaciones Individuales

### Name
- Obligatorio
- Mínimo 5 caracteres

### Age
- Obligatorio
- Debe ser numérico
- Mayor o igual a 18

### State
- Obligatorio
- Mínimo 5 caracteres

### Zipcode
- Opcional
- Si existe, debe tener exactamente 5 dígitos

### Status
- Opcional
- Solo acepta `soltero` o `casado`
- No distingue mayúsculas y minúsculas

---

## DeterminarVersion(Dictionary<string,string> datos)

Determina la versión de validación:

- Retorna `4.0` si existe `zipcode` o `status`
- Retorna `3.3` si no existen

---

## Manejo de Casos Límite

El sistema maneja correctamente:
- Entradas vacías
- Claves duplicadas
- Valores no numéricos
- Formatos incorrectos
- Campos opcionales inválidos





