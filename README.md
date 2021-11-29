
# Web API .NET Core C#

A continuación, se presenta la información acerca de la API construida usando el entorno de .NET Core mediante el lenguaje de programación C#.

------------
El contenido del archivo se dividirá en los siguientes ítems:

- Introducción
- Tecnologías usadas
- Funcionamiento de la API
- Requisitos para levantar la API

## Introducción

Para este trabajo se tomó como ejemplo un proceso de la vida cotidiana, el cual consiste en realizar pedidos de un producto, hacer el respectivo manejo de datos de compra del cliente y trasladar esos pedidos a la persona/empresa responsable de generar la logística para él envió del producto.

## Tecnologías usadas
Las tecnologías usadas para desarrollar esta web API fueron las siguientes:
- .Net Core 3.1
- C#
- SQL SERVER
- SQL Server Management Studio
- Visual Studio
- Postman
- Navegador

Como se menciona en el listado el entorno de trabajo para realizar la API fue visual studio y mediante el lenguaje C# usando .Net Core. La información que almacenaba la API debía ser guardada en una base de datos, por lo tanto se utilizó SQL Server usando SSMS. Cabe resaltar que como lenguaje de programación se usó C#.

## Funcionamiento de la API
La API de pagos tiene principalmente dos funciones, las cuales son:
- Facturar la suma total de productos por cliente.
- Enviar al servicio de logística los datos para crear un pedido nuevo.

Para lograr la primera funcionalidad, se construyó una base de datos SQL Server con los campos Id, Customer, Product, Quantity, UnitPrice, TotalPrice, cada uno con un tipo de dato consecuente a los valores que almacenaran. En esta base de datos estarán almacenados los registros de cada producto que el cliente necesita. 
En la API con un método GET obtenemos los productos que se han registrado y adicionalmente también con un método GET en la ruta *api/pagos/facturar/Customer* , obtenemos el valor total de compra de todos los productos que el cliente requiere.

La segunda funcionalidad consiste en enviar la información de pedidos a un Endpoint, para lograr esto se utilizó un método POST el cual permite mediante la ruta  *api/pagos/pedidos* se podrán enviar pedidos a un servicio de logística que será encargado de hacer la entrega de los productos al cliente. Para el servicio de logística se creó una base de datos también en SQL Server, llamada pedidos, en la cual se almacenan los pedidos que se envían por el método POST.

En el desarrollo de la API se creó un controlador llamado pagos, en donde se escribieron los métodos GET y POST utilizados, para el modelo, al incluir dos bases de datos se crearon dos modelos, pagos y pedidos. Para el manejo de datos hacia SQL se usó el context model para obtener y añadir información.

## Requisitos para levantar la API

Para levantar la API se debe configurar primero que todo el string de conexión con su SQL Server local, el cual se encuentra en el archivo appsettings.json. 
Es necesario instalar los siguientes paquetes mediante el administrados de paquetes Nuguet en el visual studio:
- Microsoft.EntityFrameworkCore.SqlServer: Usado para conectar con bases de datos relaciones SQL usando el EF.
- Microsoft.EntityFrameworkCore.Tools: Paquete para hacer uso de Entity Framework.
- Microsoft.VisualStudio.Web.CodeGenerati: Este paquete permite generar controladores para las Web Api, tambien vistas pero para este caso se usan solo controladores.

La versión de estos paquetes que se usó fue la 3.0 y teniendo todo esto instalado se procedería e ejecutar la Api en visual studio usando el IIS Express en el localHost que usted desee, el cual también puede configurar en el archivo launchSettings.json.
