- Ejecutar el Script 01-Create-Master-Database.sql para crear la Base de Datos MasterDb
- Ejecutar el Script 02-Create-Master-Tables.sql para crear las tablas de MasterDb
- Registrar una Organizaci�n => Se crear� la Base de Datos cuyo nombre representa el TenantId
- Registrar un Usuario asoci�ndolo a la Organizacion creada previamente
- Autenticar el usuario para obtener un Token de Acceso
- Realizar CRUD de Productos:
	=> QueryString slugTenant: El nombre de la Base de Datos creada para la Organizaci�n
	- AccessToken: Establecerlo en el Header de Autorizaci�n de tipo Bearer