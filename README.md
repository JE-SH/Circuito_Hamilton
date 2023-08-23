# Circuito_Hamilton

Sistema computacional que analiza imágenes e identifica los círculos negros que
existan en la misma. La aplicación debe crear un grafo a partir de la imagen analizada, cada
circulo de la imagen representa a un vértice, y cada vértice contiene adyacencias (Aristas) que
lo conectan con todos los demás siempre y cuando se pueda trazar una línea recta desde el centro
de un vértice (origen) a otro (destino). Cualquier figura en la imagen puede obstruir la conexión
de un vértice a otro, incluso los mismos vértices.

Se implementan dos algoritmos dentro del programa
1. Closest pair points: encuentra el par de centros de circulos más cercamos (la
evaluación se realiza independientemente si existen o no aristas entre los círculos).
2. Shortest Hamiltonian Circuit. Camino en el cual se pueden visitar todos los
vértices de un grafo, pasando una sola vez por cada uno, el camino empieza y termina en el mismo vértice.

## Objetivo
Crear un programa con interfaz gráfica que permita analizar imágenes e identificar su grafo mediante el
análisis de los círculos y su trayectoria con otros, y a partir de ello localizar los puntos más cercanos
entre sí, verificar si existe circuito de Hamilton y crear una animación que permita mostrar dicho
circuito.

## Diagrama de Clases UML
![imagen](https://github.com/JE-SH/Circuito_Hamilton/assets/73598536/5f8e6103-f559-462b-b82c-3c1ca755e5de)

Find center es un método en el que a partir de un pixel diferente de blanco y de un color específico de
azul, verifica si es un circulo mediante operaciones que implican el radio de lo que puede ser el circulo,
si lo es, lo pinta de un color azul para no analizarla de nuevo, ocurriendo en un bitmap secundario.
Cuando termina de analizar toda la imagen en busca de círculos el programa, la imagen que se muestra
será la original sin pintar para darle una mejor apariencia, después, se manda llamar a la clase Graph el
cual se le mandará el bitmap principal, la lista generada de los círculos en la imagen y el picture box de
la imagen principal. Ahí mismo se crean los vértices a partir de la lista de círculos. Luego se manda
llamar al método de findConection donde habrá dos vértices y un flotante que servirán para saber
cuales son los dos puntos más cercanos o closest pair points. Se crean dos arreglos para hacer
las conexiones entre dos vértices, uno de origen y otro de destino.

inGraphConection es un método que recibe dos círculos. Primero se saca la pendiente de la linea entre los dos
círculos a comparar junto con la variable lineal, todo esto nos permite encontrar los pixeles que
recorreremos en los pixeles de un eje cada pixel en el segundo eje, por ejemplo podrían ser tres pixeles
en x cada pixel en y. Dependiendo de el tipo de pendiente se verifica si es horizontal o vertical para
realizar los cálculos correctos, de ser así, cuando se localiza el tipo de pendiente y se crea un arreglo
desde el punto inicial hasta el punto final y va iterando pixel a pixel junto con la pendiente para
verificar que no haya ninguna obstrucción que sería algún pixel con un color que no se haya previsto,
ya sea diferente de un pixel del mismo circulo de origen, de destino o del mismo color del que se hace
la linea.
Posteriormente se saca la distancia entre los dos puntos independientemente si
tiene obstáculos o no para determinar cuales son los dos puntos más cercanos.
Terminando esto se imprimen las conexiones entre cada vértice.

Ya que se haya realizado el análisis de la imagen, se da clic a cualquier vértice de la imagen, Se calcula
la relación del zoom respecto con la imagen real para que el clic que se haya dado sea dentro del
vértice, si es así se manda llamar a findHamilton.

En el método del circuito de Hamilton se crea una lista de visitados, una variable con el peso del grafo,
una lista de los posibles circuitos de Hamilton, una pila con el ultimo campo visitado y una lista de vértices.
Si existe un circuito de Hamilton se verifica la linea por la que cruza respecto a dos vértices, como si se
fuera a dibujar con la diferencia de que se crea una copia del bitmap del grafo y se le sobre pone un
circulo siguiendo una trayectoria del circuito de Hamilton. Para que sea una animación rápida, el punto
aparece cada 30 pixeles dibujando el punto, haciendo una espera del programa para que parezca
continuo la aparición del punto y reemplazando la imagen creada con la imagen original para que no
aparezcan varios puntos. Si no hay circuito solo aparecerá un mensaje que no hay.
