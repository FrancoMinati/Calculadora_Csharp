# Calculadora Jerárquica 
En este repositorio se encuentra el código fuente para una calculadora que respeta las jerarquías de suma, resta, división, multiplicación y paréntesis. Se basa en el uso de árboles y lógica en el uso de los paréntesis. Fue desarrollada como proyecto global para la materia de Laboratorio de Computación en mi Tercer y Penúltimo Semestre en la Tecnicatura Universitaria en Programación.

## Funcionamiento
![arbol](https://user-images.githubusercontent.com/100171822/204065066-5fbe7ab5-fa53-4d26-b0d8-0f82f67606f2.jpg)

La estructura de funcionamiento consiste en:
1. Extraer las partes de la ecuación entre paréntesis, resolverlas y reemplazar en la ecuación a modo de simplificación
2. Iterar nuevamente en caso de la existencia de más de un nivel de paréntesis.
3. Al acabar la iteración, y obtener la ecuación en su forma más simple, es decir, sin paréntesis. Se emplea el algoritmo del árbol. El cual consiste en, dividir la ecuación introducida por pantalla e ir separando esta en Número Izquierdo y Número Derecho, la mayor parte del tiempo, este número derecho será el resto de ecuación restante. Salvo que sea una operación simple como: **2+2**. Realizando esto de forma recursiva hasta llegar al nodo más bajo del árbol. 
Cada nodo simboliza una operación, situada en base al orden de la jerarquía de las operaciones. Una vez planteado el último nodo, el más bajo del árbol, se resuelve cada nodo, hasta llegar al nodo más alto, cuya resolución determina el valor final de la ecuación.


![proceso](https://user-images.githubusercontent.com/100171822/204339436-93c47c55-539d-4014-b27c-f3046a2e030e.jpg)

_Esta es una versión simplificada del funcionamiento del arbol._

## Tecnologías
- C#
- Winforms + .NET
- Git para control de versiones

## Ejecutable
Aquí hay un link para descargar el ejecutable de la misma:

https://mega.nz/file/mFATiSba#EIHFloe2XSJuhLmV86D-0TTEl2izJCjEZ96LKTXNkmE

