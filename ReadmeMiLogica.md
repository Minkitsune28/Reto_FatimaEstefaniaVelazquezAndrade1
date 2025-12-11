# TestFatis
Este codigo tiene como objetivo que el usuario ingrese dos numeros enteros y el programa devuelva la suma de ambos.
Si alguno de los números ingresados es decimal, el programa indicará que ambos parámetros deben ser números enteros
Si alguno de los numeros ingresados no es un numero valido, es decir algun caracter que no sea numerico, el programa indicará que ambos parámetros deben ser números enteros
Y no se realizará la suma.
Este codigo está escrito en C# 

## Cómo funciona
1. En el método `Main` se llama la funcion de retoDOs con los dos parametros ingresados por el usuario
Llama la funcion mensajeResultado para mostrar el resultado o el mensaje de error
2. La funcion `SumarNumeros` se encarga de validar los parametros y realizar la suma si son validos, basicamente es la logica del reto
en bool `fst1` y `fst2` guarda el valor de si los parametros son enteros o no, lo que intenta es convertir los parametros a enteros, 
Se valida que la conversion de string a double fue exitosa, si no lo fue se retorna el mensaje de error
3.Si es correcto pasa a la siguiente validacion, que es si los numeros son enteros, para esto se compara el valor convertido a double con su version convertida a entero 
Se valida que ambos numeros sean enteros,si el residuo de la division es diferente a 0, es decimal,
Si alguno lo es se retorna el mensaje de error
Si todo es correcto se realiza la suma y se retorna el resultado como string "El resultado de la suma es: " + res + " SW"