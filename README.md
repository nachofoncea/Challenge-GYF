# Challenge-GYF

Se entrega una solución para el desafío técnico el cual requiere que para la venta, se pase un parametro que en este caso es un presupuesto, el cual debe tomarse en cuenta para retornar los productos que corresponden a la venta sin excederse del monto presupuestado

Para ello tenemos condiciones:

-Se debe ofrecer un producto de cada categoria, el de valor mas alto por cada categoria, nuevamente sin pasarse del presupuesto.

-Si no se encuentra un producto de cada categoria, el listado retornado será vacio, en dicho caso intente con un prespuesto mas alto.

-El valor que se puede introducir dentro del presupuesto está entre $0 y $1.000.000. En caso de ingresar un monto fuera de ese rango, se le avisa al usuario a través de un cartel rojo, y las validaciones tanto en el lado del cliente como en el servidor no permitirán ejecutar la "venta".

//Otros detalles

-Para este caso, tenemos creado los metodos que pueden crear, leer, editar, y eliminar tanto los productos como las categorias. De todos modos, para este caso, la edicion, creacion y eliminado de CATEGORIAS, no está disponible para el usuario a través de la interfaz visual.

-Los productos se pueden crear, borrar y editar las veces que sea, está completamente disponible para el usuario.

-En otro documento se entregan los scripts para la creacion de la base de datos.

-Para establecer conexion con la base de datos, en el archivo AppSettings.Json se debe colocar el connectionString correspondiente a la base de datos a usar.

-La interfaz de usuario está desarollada en Angular, abrir la subcarpeta del proyecto "ui-challenge-gyf" con VS Code ejecutar en la consola NPM Install (para instalar las dependencias y paquetes del proyecto) y correr el comando ng serve, si todo salió correcto debería funcionar en "http://localhost:4200/"

-Para abrir la solucion del proyecto .NET, recomiendo usar Visual Studio 2022 dado que el proyecto está en NET 7.
