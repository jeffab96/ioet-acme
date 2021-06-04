# Resolución ACME - Masache Jefferson

Solución al ejercicio planteado por IOET 

_Tema: Acme_

## Información sobre la propuesta de solución

_Aplicación de Consola desarrollada con .Net Core con el lenguaje de programación C#_

## Explicación

_Primero he desarrollado los tests para aplicar la metodología TDD (Desarrollo guiado por pruebas), de esta manera construiremos el método para que la prueba pase satisfactoriamente._

_Realice el método de Cálculo, donde como parámetro ingresa el día y el rango de horas, para devolver el valor del pago._

_Realice el método de Validar, donde al enviar varios datos en un arreglo podemos comprobar si al menos uno falla las validaciones._

_Realice el método de Procesamiento, donde se le envía una cadena de prueba completa con el nombre y los datos, para retornar el resultado calculado._

_Integré los métodos del dominio en para ser llamados desde el método ejecutar._

_Se ejecutan en la clase Principal en el método estático Main._

_Ver en **Instalación y despliegue** la explicación de cómo desplegar el proyecto._

_**Dominio**_

_En el método **Ejecutar** se recibe el nombre del archivo de texto, se abre y se procesa la cadena de texto que se recibe del archivo .txt la que se puede dividir en varios empleados si se ha manejado el estándar explicado anteriormente, para ser enviados al métodos **Procesamiento**_

_En el método **Procesamiento** Se divide el nombre y los datos de cada día ingresado con los que se crearán objetos dentro de una lista para manejar de manera estructurada los datos, aqui también se envían las cadenas al método **Validar** para comprobar si los datos están en un formato correcto._

_En el método de cálculo envíamos cada uno de estos objetos que van a producir un valor que se va a ir acumulando en una variable del método **Procesamiento** que llama a **Calculo**_

_**Limitaciones y Validaciones**_

_* No se puede ingresar horas con minutos diferentes a cero._

_* No se puede ingresar horas de fin menores a horas de inicio._

_* Las horas deben encontrarse en el formato HH:00_

_* La cadena de empleado debe estar en el siguiente formato: **(NOMBRE1)=(DIA1)(HORA_INICIO1)-(HORA_FIN1),(DIA2)(HORA_INICIO2)-(HORA_FIN2),(DIA3)(HORA_INICIO3)-(HORA_FIN3)...**_

_* Los días deben corresponder al formato abreviado indicado en el enunciado_

_* Las horas ingresadas deben encontrarse entre cada uno de los rangos indicados, no se debe cruzar con los demás rangos_

### Pre-requisitos

_.NET CORE 5.0 (Última versión del Framework desarollado por Microsoft.)_

### Instalación y Despliegue

_Al descargar el código del repositorio, ingresamos al directorio IOET.Acme.Console desde el símbolo del sistema_

_Ejecutamos el comando:_
```
> dotnet publish
```
 _Y se nos indica la ruta donde se crea el ejecutable **.exe**_

_Nos dirigimos hasta el directorio por el símbolo del sistema hasta el ejecutable y lo llamamos por la consola pasando como parámetro al archivo **.txt** con el texto que tiene los datos del nombre del empleado y sus datos de día trabajado con las horas respectivas._

_(Como plus se agregó la funcionalidad que se puedan ingresar varios empleados, separados por **';'** en la misma cadena)_

_Ejemplo de ejecución del programa con el parámetro de entrada en la consola del símbolo del sistema_

```
> IOET.Acme.Console.exe data.txt
```

_**En caso de no enviar ningún parámetro se muestra un mensaje pidiendo el parámetro de entrada**_

_Se tienen dos archivos de prueba **data_default.txt** y **data.txt**, con datos propuestos, en el directorio del proyecto de consola_


## Pruebas 

_Las pruebas son unitarias que se pueden ejecutar desde el IDE Visual Studio, el código se encuentra como proyecto adjunto dentro de la solución._

_El propio IDE nos da la opción de ingresar al proyecto y a la clase que tiene los métodos de pruebas unitarias para dar click derecho y seleccionar **Ejecutar pruebas**_

## Arquitectura

_La solución consta del proyecto de Consola y el proyecto Test_

_Proyecto de Consola: **IOET.Acme.Console**_

_Proyecto de Test: **IOET.Acme.Test**_

_Dentro del proyecto de Consola podemos encontrar varias capas como las de:_

_**Dominio.**: Se encuentra toda la lógica de negocio correspondiente a la aplicación_

_**POCO.** El objeto con el que se arma la estructura del día horas_

_**Enums.** Que contiene las enumaraciones con los datos constantes que ayudan a tener una mejor comprensión de los datos en el dominio._

_**Validación.** Cuenta con la validación de los objetos._

_**La clase Principal contiene el método "Main" el que llama al único método ejecutable del dominio.**_


## Desarrollado con:

* [Visual Studio](https://visualstudio.microsoft.com/es/) - IDE usado


## Autor 

* **Jefferson Masache** - *Desarrollo* - [jeffab96](https://github.com/jeffab96/)


---
