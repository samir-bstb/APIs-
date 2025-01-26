APIs Project
En este proyecto se trabaja con dos diferentes apis, la primera se encarga de realizar las cuatro operaciones matemáticas básicas 
(suma, resta, multiplicación y división), recibe tres números como argumentos y dos signos de operación, utilizando tanto solicitudes GET como POST.
La segunda API maneja objetos de tipo Humano que contiene atributos como Id, Id, Nombre, Sexo, Edad, Altura y Peso. Esta API utiliza 
las cuatro solicitudes del CRUD (GET, POST, UPDATE y DELETE).

Tecnologías
El proyecto de desarrolló en Visual Studio Code.
Las pruebas se realizaron en Swagger.
Se hizo uso de dos aplicaciones ASP .NET WEB API, que requiero de las intalción de las extensiones: C# Dev Kit, .NET Extension Pack, 
.NET Install Tool y .NET Install Design.

Descripción
API de operaciones matemáticas
MathControllers es el intermediario entre las solicitudes del cliente y la lógica del servidor. Recibe solicitudes HTTP GET y POST, 
llama a los métodos para ejecutar las operaciones matemáticas y devuelve una respuesta en formato JSON. Las operaciones se realizan 
en el orden en que se ingresan.

La API escucha solicitudes en la ruta /api/math/calculate.
Según el método (GET o POST), los datos son asignados a variables o deserializados en un objeto.
Los operadores (op1, op2) determinan qué operación se realiza en cada paso.

Realización de las operaciones:
Primero, se realiza la operación entre num1 y num2 usando op1, luego, el resultado se utiliza con num3 y op2 para calcular el resultado total.

El resultado de las operaciones se devuelve en un objeto JSON. Si ocurre un error o se quiere realizar una operación indebida (por ejemplo, 
división entre 0 o un operador inválido), la API devuelve un mensaje de error.

API humanos
El modelo Human define las entidades de datos con las que trabaja la aplicación. La clase Human: Representa a un humano con propiedades como 
Id, Nombre, Edad, Estatura, Peso y Género.

Los servicios HumanServices encapsulan la lógica de negocio.

Gestiona una lista estática humans que actúa como una base de datos en memoria.
Define métodos para implementar las operaciones básicas del CRUD:
GetAll(): Devuelve la lista completa de humanos.
Get(int id): Busca un humano por su Id.
Create(Human human): Añade un nuevo humano a la lista y asigna un Id único.
Delete(int id): Elimina un humano por su Id.
Update(Human human): Modifica los datos de un humano existente.
Esto permite que la lógica esté separada del controlador, facilitando las pruebas.
El Controlador HumanControllers expone los endpoints al cliente, recibiendo solicitudes HTTP, validando datos y distribuyendo la lógica a los servicios.

Notas: 
Las carpetas que incluyen las APIS son “MathOp” y Hmn_API.
Las carpetas “Attemp1” y “Human_DB” se crearon con la intención de poder hacer uso de la API humanos en relación con una base de datos. Esto no 
fue posible, por lo que se optó por manejar la API de manera local.

Pruebas 
Como se mencionó anteriormente las pruebas se realizaron en Swagger. Para esto es necesario ingresar a la terminal de Visual Studio, dirigirse 
a la carpeta del proyecto, ingresar los comandos “dotnet add package Swashbuckle.AspNetCore” y “dotnet run”, si todo funciona correctamente, 
entre uno de los mensajes que se muestran, se encontrará un comentario similar al siguiente: “Now listening on: http://localhost:5000 “. 
Por lo que solamente sería necesario ingresar a Now listening on: http://localhost:5000/swagger para probar el funcionamiento de las APIs.
